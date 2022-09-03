namespace Domain.Exceptions.ModelSpecific
{
    public sealed class RefreshTokenBadRequest : BadRequestException
    {
        public RefreshTokenBadRequest()
            : base("Invalid client request. The tokenDto has some invalid values.")
        {
        }
    }
}