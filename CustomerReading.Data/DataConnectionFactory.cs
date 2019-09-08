using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CustomerReading.Data
{
    public class DataConnectionFactory
    {
        private readonly string connectionString;

        public DataConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public SqlConnection Get()
        {
            return new SqlConnection(connectionString);
        }

    }
}
