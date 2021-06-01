using DataModel;

using System;
using System.Collections.Generic;
using System.Text;
using DataRepository;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;

namespace ServiceClassLibrary
{
    class UserServiceClass : UserServiceInterface
    {
        private readonly UserOperationInterface _PasswordComplexityRulesOperations;
        public void Delete(int id)
        {
            _PasswordComplexityRulesOperations.Delete(id);
        }
         
        public UserDataModel GetUser(int id)
        {
          return  _PasswordComplexityRulesOperations.GetById(id);

        }

        public void SaveUser(UserDataModel User)
        {
            throw new NotImplementedException();
        }

        public List<UserDataModel> list()
        {
            return _PasswordComplexityRulesOperations.list();
        }

       
    }
}
