using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Components
{
    public class SqlServerInstance
    {
        public static Server Server;
        public static string StringConnection =
                @"Server=SEC_SQL;Database={0};
                        User ID=check_infra;
                        Password=*********;
                        Trusted_Connection=True;
                        Connection Timeout=0";
        private bool _disposed;

        public SqlServerInstance()
        {
            createServerInstance();
        }

        private void createServerInstance()
        {
            Server = new Server();
            Server.ConnectionContext.ConnectionString = string.Format(StringConnection, "master");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Server != null)
                        Server.ConnectionContext.Disconnect();
                }

                Server = null;
                _disposed = true;

                SqlConnection.ClearAllPools();
            }
        }
    }
}
