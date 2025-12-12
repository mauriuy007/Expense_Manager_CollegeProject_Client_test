namespace LibreriaLogicaAplicacion.Dtos.User
{
    public record UserCreateDto(
        string name,
        string lastName,
        string password,
        int teamId,
        string role
    );

}
