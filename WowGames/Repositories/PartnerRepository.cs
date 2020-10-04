using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WowGames.Models;

namespace WowGames.Repositories
{
    public class PartnerRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["WOW_GAMES"].ConnectionString;

        public List<Partner> List()
        {
            var retorno = new List<Partner>();

            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand($"SELECT * FROM [PARTNER]", sqlCon))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        retorno.Add(new Partner
                        {
                            Id = Convert.ToInt32(dr["PartnerId"].ToString()),
                            Name = dr["Partner"].ToString()
                        });
                    }
                }
                sqlCon.Close();
            }

            return retorno;
        }
    }
}