using System.Data;
using System.Data.SqlClient;

namespace FakingExample
{
    public static class DataAccessLayer
    {
        public static int SaveCartItem(int cartId, int productId)
        {
            using (var conn = new SqlConnection("RandomSqlConnectionString"))
            {
                var cmd = new SqlCommand("InsCartItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartId", cartId);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
