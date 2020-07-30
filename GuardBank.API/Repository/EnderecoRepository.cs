using GuardBank.API.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using GuardBank.API.Repository.Interfaces;

namespace GuardBank.API.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        IConfiguration _configuration;
        private readonly string _connectionStringGuardBank;

        public EnderecoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionStringGuardBank = configuration.GetConnectionString("GuardBankConnection");
        }

        public int Add(Endereco endereco)
        {
            
            int count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "INSERT INTO Endereco(SobreClienteId, Guid, Cep, Rua, Cidade, Bairro, Estado, Numero, Complemento ) VALUES(@SobreClienteId, @Guid, @Cep, @Rua, @Cidade, @Bairro, @Estado, @Numero, @Complemento ) ";
                    count = con.Execute(query, endereco);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return count;
            }
        }
       
        public int Edit(Endereco endereco)
        {           
            var count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "UPDATE Endereco SET Cep = @Cep, Rua = @Rua, Cidade = @Cidade, Bairro = @Bairro, Estado = @Estado, Numero = @Numero, Complemento = @Complemento WHERE EnderecoId = " + endereco.EnderecoId;
                    count = con.Execute(query, endereco);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
                return count;
            }
        }

        public Endereco Get(int id)
        {   
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    return con.QueryFirstOrDefault<Endereco>(
                        @"SELECT * FROM Endereco (nolock)
                         WHERE EnderecoId = @Id",
                         new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
      
    }
}
