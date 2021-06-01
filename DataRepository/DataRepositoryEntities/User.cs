 using DataRepository;
using System;
using System.Collections.Generic;
using System.Net;

#nullable disable


namespace DataRepository.DataRepositoryEntities
{
    public partial class User: IRepository
    {
        public User()
        {
           
            
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
      
      
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
     

        //public virtual User CreatedByNavigation { get; set; }
        //public virtual User LastUpdateByNavigation { get; set; }
     
    }
}
