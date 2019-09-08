using CustomerReading.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReading.Data
{
   public class UserDataService: IUserDataService
    {
        private readonly DataConnectionFactory connectionFactory;

        public UserDataService(DataConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void AuthenticateUser() {

        }

        public bool UserLogin(UserLogin user)
        {
            //using (var con = connectionFactory.Get())
            //{
            //    var cmd = con.CreateCommand();

            //}
            return true;
        }
    }
}
