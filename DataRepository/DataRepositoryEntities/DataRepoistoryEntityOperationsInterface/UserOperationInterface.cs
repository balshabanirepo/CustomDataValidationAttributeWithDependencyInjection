using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface
{
   public interface UserOperationInterface
    {
        public void SaveUser(UserDataModel systemSettings);




        public void Delete(int id);


        UserDataModel GetById(int id);

        public List<UserDataModel> list();
    }
}
