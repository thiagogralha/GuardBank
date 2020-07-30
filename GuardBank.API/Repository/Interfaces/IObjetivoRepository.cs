using GuardBank.API.Entities;
using System.Collections.Generic;

namespace GuardBank.API.Repository.Interfaces
{
    public interface IObjetivoRepository
    {
        int Add(Objetivo objetivo);
        Objetivo Get(int id);
        int Delete(int id);
        List<Objetivo> GetTodosObjetivos(int sobreClienteId);
        int Edit(Objetivo objetivo);
    }
}
