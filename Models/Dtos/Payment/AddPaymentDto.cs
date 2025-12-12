namespace N3C_348209_parodi_client.Models.Dtos.Payment
{
    public record AddPaymentDto(
        string PaymentMethod,
        string Description,
        double Amount,
        int ExpenseId,
        string PaymentType,
        DateTime? DateFrom,
        DateTime? DateTill,
        DateTime? PayDate,
        string? BillNumber,
        int UserId
    );
}