using GuardBank.API.Entities;
using System.Collections.Generic;

namespace GuardBank.API.Repository.Interfaces
{
    public interface IEnderecoRepository
    {
        int Add(Endereco endereco);
        Endereco Get(int id);
        int Edit(Endereco endereco);

    }
}
