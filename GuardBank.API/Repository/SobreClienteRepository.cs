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
    public class SobreClienteRepository : ISobreClienteRepository
    {
        IConfiguration _configuration;
        private readonly string _connectionStringGuardBank;

        public SobreClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionStringGuardBank = configuration.GetConnectionString("GuardBankConnection");
        }

        public int Add(SobreCliente sobreCliente)
        {
            
            int count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "INSERT INTO SobreCliente(Guid, NomeApelido, Email, ConfirmarEmail, Senha, Role, DataCadastro ) VALUES(@Guid, @NomeApelido, @Email, @ConfirmarEmail, @Senha, @Role, GETDATE() ) ";
                    count = con.Execute(query, sobreCliente);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return count;
            }
        }
          
        public SobreCliente Get(int id)
        {   
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    return con.QueryFirstOrDefault<SobreCliente>(
                        @"SELECT * FROM SobreCliente
                         WHERE SobreClienteId = @Id",
                         new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
              
        public SobreCliente Authenticate(SobreCliente sobreCliente)
        {
            
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    return  con.QueryFirstOrDefault<SobreCliente>(
                        @"SELECT * FROM SobreCliente
                         WHERE Email = @SobreEmail
                         AND Senha = @SobreSenha",
                         new { SobreEmail = sobreCliente.Email, SobreSenha = sobreCliente.Senha });

                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
            }
        }
    }
}
