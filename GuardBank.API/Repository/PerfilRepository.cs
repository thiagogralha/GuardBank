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
    public class PerfilRepository : IPerfilRepository
    {
        IConfiguration _configuration;
        private readonly string _connectionStringGuardBank;

        public PerfilRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionStringGuardBank = configuration.GetConnectionString("GuardBankConnection");
        }

        public int Add(Perfil perfil)
        {
            
            int count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = @"INSERT INTO Perfil(SobreClienteId, Guid, NomeCompleto, DataNascimento, CPF, Celular, AceitaTermo ) 
                                    VALUES(@SobreClienteId, @Guid, @NomeCompleto, @DataNascimento, @CPF, @Celular, @AceitaTermo ) ";
                    count = con.Execute(query, perfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return count;
            }
        }

        public Perfil Get(int id)
        {
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    return con.QueryFirstOrDefault<Perfil>(
                        @"SELECT * FROM Perfil
                         WHERE PerfilId = @Id",
                         new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Perfil GetPerfilSobreCliente(int sobreClienteId)
        {   
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    return con.QueryFirstOrDefault<Perfil>(
                        @"SELECT * FROM Perfil (nolock)
                         WHERE SobreClienteId = @SobreClienteId",
                         new { SobreClienteId = sobreClienteId });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
