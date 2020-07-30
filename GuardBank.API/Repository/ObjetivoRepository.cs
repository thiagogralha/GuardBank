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
    public class ObjetivoRepository : IObjetivoRepository
    {
        IConfiguration _configuration;
        private readonly string _connectionStringGuardBank;

        public ObjetivoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionStringGuardBank = configuration.GetConnectionString("GuardBankConnection");
        }

        public int Add(Objetivo objetivo)
        {
            
            int count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "INSERT INTO Objetivo(SobreClienteId, Guid, Descricao, ValorMensal, Tempo, Total ) VALUES(@SobreClienteId, @Guid, @Descricao, @ValorMensal, @Tempo, @Total ) ";
                    count = con.Execute(query, objetivo);
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
                    var query = "DELETE FROM Objetivo WHERE ObjetivoId = " + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return count;
            }
        }

        public int Edit(Objetivo objetivo)
        {           
            var count = 0;
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {                    
                    var query = "UPDATE Objetivo SET Descricao = @Descricao, ValorMensal = @ValorMensal, Tempo = @Tempo, Total = @Total WHERE ObjetivoId = " + objetivo.ObjetivoId;
                    count = con.Execute(query, objetivo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
                return count;
            }
        }

        public Objetivo Get(int id)
        {   
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    return con.QueryFirstOrDefault<Objetivo>(
                        @"SELECT * FROM Objetivo (nolock)
                         WHERE ObjetivoId = @Id",
                         new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Objetivo> GetTodosObjetivos(int sobreClienteId)
        {            
            List<Objetivo> lstObjetivos = new List<Objetivo>();
            using (var con = new SqlConnection(_connectionStringGuardBank))
            {
                try
                {
                    var query = @"SELECT * FROM Objetivo (nolock) 
                                    WHERE SobreClienteId = " + sobreClienteId;
                    lstObjetivos = con.Query<Objetivo>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
                return lstObjetivos;
            }
        }

    }
}
