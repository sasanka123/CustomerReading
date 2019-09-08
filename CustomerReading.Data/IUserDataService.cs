using CustomerReading.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReading.Data
{
    public interface IUserDataService
    {
        bool UserLogin(UserLogin user);
    }
}
