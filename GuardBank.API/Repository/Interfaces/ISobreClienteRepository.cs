using GuardBank.API.Entities;
using System.Collections.Generic;

namespace GuardBank.API.Repository.Interfaces
{
    public interface ISobreClienteRepository
    {
        int Add(SobreCliente sobreCliente);
        SobreCliente Get(int id);
        SobreCliente Authenticate(SobreCliente sobreCliente);
    }
}
