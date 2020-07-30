using GuardBank.API.Entities;
using System.Collections.Generic;

namespace GuardBank.API.Repository.Interfaces
{
    public interface IPerfilRepository
    {
        int Add(Perfil perfil);
        Perfil Get(int id);
        Perfil GetPerfilSobreCliente(int sobreClienteId);       
    }
}
