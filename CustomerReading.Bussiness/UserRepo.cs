using CustomerReading.Data;
using CustomerReading.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReading.Bussiness
{
    public class UserRepo
    {
        private readonly IUserDataService userDataService;

        public UserRepo(IUserDataService userDataService)
        {
            this.userDataService = userDataService;
        }

        public bool UserLogin(UserLogin userLogin) {
            return userDataService.UserLogin(userLogin);
 
        }
    }
}
