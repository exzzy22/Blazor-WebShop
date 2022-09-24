namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        IEnumerable<RoleDto> Roles();
        Task<IdentityResult> CreateRole(string roleName);
        Task<IdentityResult> RemoveRole(int roleId);
    }
}