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
    public class ContasCadastradasRepository : IContasCadastradasRepository
    {
        IConfiguration _configuration;
        private readonly string _connectionStringGuardBank;

        public ContasCadastradasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionStringGuardBank = configuration.GetConnectionString("GuardBankConnection");
        }

        public int Add(ContasCadastradas contaCadastrada)
        {
            
            int count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "INSERT INTO ContasCadastradas(SobreClienteId, Guid, Banco, Agencia, Conta, DataCadastro ) VALUES(@SobreClienteId, @Guid, @Banco, @Agencia, @Conta, GETDATE() ) ";
                    count = con.Execute(query, contaCadastrada);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return count;
            }
        }

        public int Delete(int id)
        {           
            var count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "DELETE FROM ContasCadastradas WHERE ContaCadastradaId = " + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return count;
            }
        }

        public int Edit(ContasCadastradas contaCadastrada)
        {           
            var count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "UPDATE ContasCadastradas SET Banco = @Banco, Agencia = @Agencia, Conta = @Conta WHERE ContaCadastradaId = " + contaCadastrada.ContaCadastradaId;
                    count = con.Execute(query, contaCadastrada);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
                return count;
            }
        }

        public ContasCadastradas Get(int id)
        {   
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    return con.QueryFirstOrDefault<ContasCadastradas>(
                        @"SELECT * FROM ContasCadastradas (nolock)
                         WHERE ContaCadastradaId = @Id",
                         new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<ContasCadastradas> GetTodasContasCadastradas(int sobreClienteId)
        {            
            List<ContasCadastradas> lstContasCadastradas = new List<ContasCadastradas>();
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    var query = @"SELECT * FROM ContasCadastradas (nolock) 
                                    WHERE SobreClienteId = " + sobreClienteId;
                    lstContasCadastradas = con.Query<ContasCadastradas>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
                return lstContasCadastradas;
            }
        }

    }
}
