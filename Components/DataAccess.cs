using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Components
{
    public class DataAccess
    {
        public static SqlCommand commandToText(string script)
        {
            return new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = script
            };
        }

        public static SqlCommand commandToSP(string parameter)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VALIDAR_BASE_MOVIL";
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@P_PERIODO_STAR",
                Value = "012015",
                SqlDbType = SqlDbType.VarChar
            });
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@P_DATABASE_NAME",
                Value = parameter,
                SqlDbType = SqlDbType.VarChar
            });

            return cmd;
        }

        public static void executeCommand(SqlCommand cmd)
        {            
            var cnn = new SqlConnection
            {
                ConnectionString =
                    string.Format(SqlServerInstance.StringConnection, "VALIDACION_BASES_MOVILES")
            };

            cmd.Connection = cnn;
            cmd.CommandTimeout = 0;

            if (cnn.State != ConnectionState.Open)
                cnn.Open();

            var data = cmd.ExecuteNonQuery();
            
        }
    }
}
