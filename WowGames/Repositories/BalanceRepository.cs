using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WowGames.Models;

namespace WowGames.Repositories
{
    public class BalanceRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["WOW_GAMES"].ConnectionString;

        public void Add(decimal amount)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand("INSERT INTO BALANCE VALUES (@AMOUNT,GETDATE())", sqlCon))
                {
                    cmd.Parameters.Add(new SqlParameter("AMOUNT", SqlDbType.Decimal) { Direction = ParameterDirection.Input, Value = amount});
                    cmd.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        public List<BalanceDetail> GetBalance(int days)
        {
            var retorno = new List<BalanceDetail>();
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand($"GET_BALANCE {days}", sqlCon))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        retorno.Add(new BalanceDetail
                        {
                            Id = Convert.ToInt32(dr["RID"].ToString()),
                            Date = Convert.ToDateTime(dr["DATE"].ToString()),
                            Amount = Convert.ToDecimal(dr["AMOUNT"].ToString()),
                            Balance = Convert.ToDecimal(dr["BALANCE"].ToString()),
                            Description = dr["DESC"].ToString()

                        });
                    }
                }
                sqlCon.Close();
            }

            return retorno;
        }
    }
}