namespace N3C_348209_parodi_client.Models.Dtos.User
{
    public record UserLoginResponseDto(
        int Id,
        string Email,
        string Role,
        string Token
    );
}
