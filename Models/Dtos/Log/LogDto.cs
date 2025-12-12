namespace N3C_348209_parodi_client.Models.Dtos.Log
{
    public record LogDto(
        Guid Id,
        string Message,
        string Operation,
        DateTime DateTime,
        int ExpenseId,
        int UserId
    );
}
