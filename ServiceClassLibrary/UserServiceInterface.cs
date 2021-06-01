using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceClassLibrary
{
    public interface UserServiceInterface
    {
        public void Delete(int id);

        public void SaveUser(UserDataModel User);

        public UserDataModel GetUser(int id);

        public List<UserDataModel> list();


    }
}
