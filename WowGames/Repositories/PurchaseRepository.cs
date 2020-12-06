using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WowGames.Models;

namespace WowGames.Repositories
{
    public class PurchaseRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["WOW_GAMES"].ConnectionString;

        public void Add(Purchase purchase)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand("INSERT INTO PURCHASE VALUES (@date,@serial,@token,@suggestedPrice,@paidPrice,@partnerId,@sku,@transaction,@receipt,@cancelled,@cancelDate)", sqlCon))
                {
                    cmd.Parameters.Add(new SqlParameter("date", SqlDbType.DateTime) { Direction = ParameterDirection.Input, Value = purchase.PurchaseDate });
                    cmd.Parameters.Add(new SqlParameter("serial", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = purchase.Serial, Size = 50 });
                    cmd.Parameters.Add(new SqlParameter("token", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = purchase.Token, Size = 50 });
                    cmd.Parameters.Add(new SqlParameter("suggestedPrice", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = purchase.SuggestedPrice, Size = 50 });
                    cmd.Parameters.Add(new SqlParameter("paidPrice", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = purchase.PaidPrice, Size = 50 });
                    cmd.Parameters.Add(new SqlParameter("partnerId", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = purchase.PartnerId });
                    cmd.Parameters.Add(new SqlParameter("sku", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = purchase.Sku, Size = 50 });
                    cmd.Parameters.Add(new SqlParameter("transaction", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(purchase.TransactionId) ? DBNull.Value : (object)purchase.TransactionId, Size = 250 });
                    cmd.Parameters.Add(new SqlParameter("receipt", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(purchase.Receipt) ? DBNull.Value : (object)purchase.Receipt, Size = -1 });
                    cmd.Parameters.Add(new SqlParameter("cancelled", SqlDbType.Bit) { Direction = ParameterDirection.Input, Value = purchase.Cancelled });
                    cmd.Parameters.Add(new SqlParameter("cancelDate", SqlDbType.DateTime) { Direction = ParameterDirection.Input, Value = !purchase.Cancelled ? DBNull.Value : (object)DateTime.Now });
                    cmd.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        public List<Purchase> Search(DateTime? dataInicio, DateTime? dataFim, string sku, string pin)
        {
            var retorno = new List<Purchase>();
            var where = " where 1 = 1 ";
            if (dataInicio.HasValue)
                where += $"  AND CONVERT(VARCHAR,PURCHASEDATE,111)  >= '{dataInicio.Value.ToString("yyyy/MM/dd")}'";
            if (dataFim.HasValue)
                where += $"  AND CONVERT(VARCHAR,PURCHASEDATE,111)  <= '{dataFim.Value.ToString("yyyy/MM/dd")}'";
            if (!string.IsNullOrEmpty(sku))
                where += "  AND Sku LIKE '%'+@sku+'%'";
            if (!string.IsNullOrEmpty(pin))
                where += "  AND Token = @pin";
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand($"SELECT P.*, PP.Partner FROM [PURCHASE] P JOIN [PARTNER] PP ON P.PartnerId = PP.PartnerId {where} ORDER BY PurchaseDate DESC", sqlCon))
                {
                    if (!string.IsNullOrEmpty(sku))
                        cmd.Parameters.Add(new SqlParameter("sku", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = sku, Size = 50 });
                    if (!string.IsNullOrEmpty(pin))
                        cmd.Parameters.Add(new SqlParameter("pin", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = pin, Size = 50 });

                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        retorno.Add(new Purchase
                        {
                            Token = dr["Token"].ToString(),
                            PartnerId = Convert.ToInt32(dr["PartnerId"].ToString()),
                            Serial = dr["Serial"].ToString(),
                            SuggestedPrice = dr["SuggestedSalePrice"].ToString(),
                            PaidPrice = dr["PaidPrice"].ToString(),
                            Sku = dr["Sku"].ToString(),
                            PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"]),
                            Partner = dr["Partner"].ToString(),
                            TransactionId = dr["TransactionId"].ToString(),
                            Receipt = dr["Receipt"].ToString(),
                            PurchaseId = Convert.ToInt32(dr["PurchaseId"].ToString()),
                            Cancelled = Convert.ToBoolean(dr["Cancelled"].ToString()),
                            CancelDate = dr["CancelDate"] != DBNull.Value ? new DateTime?(Convert.ToDateTime(dr["CancelDate"])) : new DateTime?(),

                        }); ;
                    }
                }
                sqlCon.Close();
            }

            return retorno;
        }

        public bool CancelPurchase(int purchaseId)
        {
            using (var sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (var cmd = new SqlCommand("UPDATE PURCHASE SET CANCELLED = 1, CANCELDATE = GETDATE() WHERE PurchaseID = @ID", sqlCon))
                {
                    cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = purchaseId });
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }

        }
    }
}