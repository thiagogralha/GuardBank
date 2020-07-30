using GuardBank.API.Entities;
using System.Collections.Generic;

namespace GuardBank.API.Repository.Interfaces
{
    public interface IContasCadastradasRepository
    {
        int Add(ContasCadastradas contasCadastradas);
        ContasCadastradas Get(int id);
        int Edit(ContasCadastradas contasCadastradas);
        int Delete(int id);
        List<ContasCadastradas> GetTodasContasCadastradas(int sobreClienteId);

    }
}
