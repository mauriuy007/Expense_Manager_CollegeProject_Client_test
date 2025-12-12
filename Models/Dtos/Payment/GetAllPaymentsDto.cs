namespace LibreriaLogicaAplicacion.Dtos.Payment
{
    public class GetAllPaymentsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string ExpenseType { get; set; }
        public DateTime? PayDate { get; set; }
        public string PaymentType { get; set; }
        public double RemainingBalance { get; set; }
    }
}
