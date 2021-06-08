using DataModel;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;
using ServiceClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceClassLibrary
{
    public class UserServiceClass: UserServiceInterface
    {

       
            private readonly UserOperationInterface _userOperationInterface;

        public UserServiceClass(UserOperationInterface userOperationInterface)
        {
            // settingsModelMapper = new PasswordComplexityRulesModelMapper();

            _userOperationInterface = userOperationInterface;
        }
        public void Delete(int id)
            {
            _userOperationInterface.Delete(id);
            }

            public UserDataModel GetUser(int id)
            {
                return _userOperationInterface.GetById(id);

            }

            public void SaveUser(UserDataModel User)
            {
            _userOperationInterface.SaveUser(User);
            }

            public List<UserDataModel> list()
            {
                return _userOperationInterface.list();
            }


        
    }
}


