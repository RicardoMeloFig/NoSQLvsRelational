using Microsoft.Data.SqlClient;
using System.Data;

namespace NoSQLvsRelational
{
    public class SQL_CRUD
    {
        const string conString = "Data Source=DESKTOP-RAPFS13\\SQLEXPRESS;Initial Catalog=Teste;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public int insertDocument()
        {
            string strCommand = "Insert into Teste2(teste) values ('sqlConnected')";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand(strCommand, connection);
                command.Connection.Open();
                return command.ExecuteNonQuery();

            }
        }

        public void updateDocument()
        {
            string strCommand = "UPDATE Teste2 SET teste = 'UpdatedColumn' WHERE id = 3";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand(strCommand, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public void deleteDocument()
        {
            string strCommand = "Delete from Teste2 WHERE id = 3";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand(strCommand, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public void getAllDocuments()
        {
            string strCommand = "Select * from Teste2";
            
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand(strCommand, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var x = reader.Select(r => 
                (
                    r["id"] is DBNull ? null : r["id"].ToString(),
                    r["teste"] is DBNull ? null : r["teste"].ToString()
                )).ToList();

                // Call Close when done reading.
                reader.Close();

            }
        }

        public void getDocumentById(int id)
        {
            string strCommand = "Select * from Teste2 where id = "+id;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand(strCommand, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    //ReadSingleRow((IDataRecord)reader);
                }

                // Call Close when done reading.
                reader.Close();

            }
        }
        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }

    }
}
