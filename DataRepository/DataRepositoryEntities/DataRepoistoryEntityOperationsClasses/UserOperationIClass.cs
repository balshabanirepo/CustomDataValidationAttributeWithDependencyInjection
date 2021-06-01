using DataModel;
using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsInterface;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses
{
    class UserOperationIClass : UserOperationInterface
    {
        IContextGateWay _contextGateWay;
        public UserOperationIClass(IContextGateWay contextGateWay)
        {
            _contextGateWay = contextGateWay;

        }
        public void Delete(int id)
        {
            _contextGateWay.Users.Delete(_contextGateWay.Users.GetById(g => g.Id==id));
        }

        public UserDataModel GetById(int id)
        {
            UserDataModel userDataModel;
            User user=
            user= _contextGateWay.Users.GetById(g => g.Id == id);
            userDataModel = new UserDataModel
            {
                Id = user.Id,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };
            return userDataModel;
        }

        public List<UserDataModel> list()
        {
            List<User> users = _contextGateWay.Users.List();
            return (from user in users
                    select
                new UserDataModel
                {
                    Id = user.Id,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName
                }).ToList();

        }

        public void SaveUser(UserDataModel userDataModel)
        {
           
            if (userDataModel.Id>0)
            {
                User user = _contextGateWay.Users.GetById(g => g.Id == userDataModel.Id),
                    user1 = new User
                    {
                        Id = userDataModel.Id,
                        Password = userDataModel.Password,
                        FirstName = userDataModel.FirstName,
                        LastName = userDataModel.LastName,
                        UserName = userDataModel.UserName
                    };
                _contextGateWay.Users.Edit(user, user1);
            }
            else
            {
                _contextGateWay.Users.Add(new User
                {
                    Id = userDataModel.Id,
                    Password = userDataModel.Password,
                    FirstName = userDataModel.FirstName,
                    LastName = userDataModel.LastName,
                    UserName = userDataModel.UserName
                });
            }
        }
    }
}
