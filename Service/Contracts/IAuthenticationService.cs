namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateTokenAsync(bool populateExp);
        Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);
        Task<IList<User>> GetUsersInRoleAsync(string roleName);
        Task<IdentityResult> CreateAdminAsync(AdminForCreationDto admin);
        Task<IdentityResult> UpdateAdminAsync(AdminDto admin);
        Task<IdentityResult> DeleteAdminAsync(int adminId);

    }
}