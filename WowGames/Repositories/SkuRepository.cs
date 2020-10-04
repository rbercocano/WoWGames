using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WowGames.Models;

namespace WowGames.Repositories
{
    public class SkuRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["WOW_GAMES"].ConnectionString;

        public void Add(PartnerSku entity)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand("INSERT INTO PartnerSKU VALUES (@SKU,@Description,@PartnerId)", sqlCon))
                {
                    cmd.Parameters.Add(new SqlParameter("SKU", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = entity.SKU, Size = 50 });
                    cmd.Parameters.Add(new SqlParameter("Description", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = entity.Description, Size = -1 });
                    cmd.Parameters.Add(new SqlParameter("partnerId", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = entity.PartnerId });
                    cmd.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        public void Remove(int partnerSkuId)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand("DELETE FROM PartnerSKU WHERE ID = @ID", sqlCon))
                {
                    cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = partnerSkuId });
                    cmd.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        public List<PartnerSku> Search(int? partnerId, string sku)
        {
            var retorno = new List<PartnerSku>();
            var where = " where 1 = 1 ";
            if (partnerId.HasValue)
                where += $" AND P.PartnerId = {partnerId}";
            if (!string.IsNullOrEmpty(sku))
                where += $" AND SKU LIKE '%{sku}%'";

            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand($"SELECT P.*, PP.Partner FROM [PartnerSKU] P JOIN [PARTNER] PP ON P.PartnerId = PP.PartnerId {where} ORDER BY 2", sqlCon))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        retorno.Add(new PartnerSku
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            PartnerId = Convert.ToInt32(dr["PartnerId"].ToString()),
                            Description = dr["Description"].ToString(),
                            SKU = dr["Sku"].ToString(),
                            Partner = dr["Partner"].ToString(),
                        });
                    }
                }
                sqlCon.Close();
            }

            return retorno;
        }
        public PartnerSku Get(int partnerId, string sku)
        {
            var where = $" where P.PartnerId = {partnerId} AND SKU = '{sku}'";

            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand($"SELECT P.*, PP.Partner FROM [PartnerSKU] P JOIN [PARTNER] PP ON P.PartnerId = PP.PartnerId {where} ORDER BY 2", sqlCon))
                {
                    var dr = cmd.ExecuteReader();
                    dr.Read();
                    if (!dr.HasRows) return null;
                    return new PartnerSku
                    {
                        Id = Convert.ToInt32(dr["Id"].ToString()),
                        PartnerId = Convert.ToInt32(dr["PartnerId"].ToString()),
                        Description = dr["Description"].ToString(),
                        SKU = dr["Sku"].ToString(),
                        Partner = dr["Partner"].ToString(),
                    };


                }
            }

        }
    }
}