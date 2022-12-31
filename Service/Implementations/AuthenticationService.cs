namespace Service.Implementations
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IOptions<JwtConfiguration> _configuration;
        private readonly JwtConfiguration _jwtConfiguration;

        private User? _user;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, RoleManager<Role> roleManager,
            UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _jwtConfiguration = _configuration.Value;
        }

        public async Task<UserDto> GetUserInfo(ClaimsPrincipal user)
        {
            User dbUser = await _userManager.FindByNameAsync(user.Identity.Name) ?? throw new UserNotFound();

			return _mapper.Map<UserDto>(dbUser);
		}

		public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration)
        {
            User user = _mapper.Map<User>(userForRegistration);
            user.UserName = Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, DatabaseConstants.RoleConstants.User.Name);
            }

            return result;
        }

        public async Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByEmailAsync(userForAuth.Email);

            bool result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if (!result)
                _logger.LogWarn($"{nameof(ValidateUserAsync)}: Authentication failed. Wrong user name or password.");

            return result;
        }

        public async Task<TokenDto> CreateTokenAsync(bool populateExp)
        {
            SigningCredentials signingCredentials = GetSigningCredentials();
            List<Claim> claims = await GetClaims();
            JwtSecurityToken tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            string refreshToken = GenerateRefreshToken();

            if (_user is null)
                throw new UserNotFound();

            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddHours(_jwtConfiguration.RefreshTokenExpiration);

            await _userManager.UpdateAsync(_user);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(accessToken, refreshToken);
        }

        public async Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto)
        {
            ClaimsPrincipal principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            User? user = await _userManager.FindByNameAsync(principal.Identity?.Name);

            if (user is null)
                throw new UserNotFound();

            if (user == null ||
                user.RefreshToken != tokenDto.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            this._user = user;

            return await CreateTokenAsync(populateExp: false);
        }

        public async Task<IdentityResult> UpdateAdminAsync(AdminDto admin)
        {
            User adminDb = await _userManager.FindByIdAsync(admin.Id.ToString()) ?? throw new UserNotFound();

            return await _userManager.UpdateAsync(_mapper.Map(admin, adminDb));
        }

        public async Task<IdentityResult> DeleteAdminAsync(int adminId)
        {
            User admin = await _userManager.FindByIdAsync(adminId.ToString()) ?? throw new UserNotFound();

			return await _userManager.DeleteAsync(admin);
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task<IdentityResult> CreateAdminAsync(AdminForCreationDto admin)
        {
            User user = _mapper.Map<User>(admin);

            user.UserName = Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, admin.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, DatabaseConstants.RoleConstants.Administrator.Name);
            }

            return result;
        }

        private static string GenerateRefreshToken()
        {
            byte[] randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new ()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtConfiguration.Secret)),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };

            JwtSecurityTokenHandler tokenHandler = new ();
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);


            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        private SigningCredentials GetSigningCredentials()
        {
            byte[] key = Encoding.UTF8.GetBytes(_jwtConfiguration.Secret);
            SymmetricSecurityKey secret = new (key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            if (_user is null)
                throw new UserNotFound();

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            IList<string> roles = await _userManager.GetRolesAsync(_user);

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.Email,_user.Email));

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            JwtSecurityToken tokenOptions = new
            (
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_jwtConfiguration.AccessTokenExpiration)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
	}
}