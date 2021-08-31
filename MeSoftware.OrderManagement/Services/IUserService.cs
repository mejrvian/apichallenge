using System;
using System.Collections.Generic;
using MeSoftware.OrderManagement.Models;

namespace MeSoftware.OrderManagement.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(Guid id);
    }
}
