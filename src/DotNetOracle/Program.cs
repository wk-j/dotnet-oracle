using System;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DotNetOracle {
    class Program {
        static void Main(string[] args) {
            var connectionString = "User Id=system;Password=oracle;Data Source=localhost:49161/xe";

            using (var connection = new OracleConnection(connectionString))
            using (var command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM Help";

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    Console.WriteLine("Info: " + reader.GetString(0));
                }
            }
        }
    }
}