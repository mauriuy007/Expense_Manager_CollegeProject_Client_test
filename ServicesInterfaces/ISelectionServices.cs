using LibreriaLogicaAplicacion.Dtos.Expense;
using LibreriaLogicaAplicacion.Dtos.User;

namespace N3C_348209_parodi_client.ServicesInterfaces
{
    public interface ISelectionServices
    {
        IEnumerable<ExpenseDto> GetExpensesForSelect();
        IEnumerable<UserSelectDto> GetUsersForSelect();
    }
}
