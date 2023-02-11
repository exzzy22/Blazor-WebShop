namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<UserDto> GetUserInfo(ClaimsPrincipal user);
    Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration);
    Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto changePassword, ClaimsPrincipal user);
	Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuth);
    Task<bool> ValidateAdminAsync(UserForAuthenticationDto userForAuth);
    Task<TokenDto> CreateTokenAsync(bool populateExp);
    Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);
    Task<IList<User>> GetUsersInRoleAsync(string roleName);
    Task<IdentityResult> CreateAdminAsync(AdminForCreationDto admin);
    Task<IdentityResult> UpdateAdminAsync(AdminDto admin);
    Task<IdentityResult> UpdateUserAsync(UserDto user);
    Task<IdentityResult> DeleteAdminAsync(int adminId);
    Task SubscribeNewsLetter(string email);
}