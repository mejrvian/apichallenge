using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeSoftware.Core;
using MeSoftware.Exceptions.Api;
using MeSoftware.OrderManagement.Contexts;
using MeSoftware.OrderManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly MeContext context;

        public UserService(MeContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public User Authenticate(string username, string password)
        {
            if (!username.HasValue().Or(!password.HasValue()))
                throw new MeAuthenticateException("Wrong Credentials");

            var user = context.Users
                .FirstOrDefault(x => x.NormalizedUserName.Equals(username.ToUpper()));

            // check if username exists
            if (user.IsNull().Or(user.ActiveFlag.GetValueOrDefault().Not()))
                throw new MeAuthenticateException("User do not exist");

            // check if password is correct
            var isPwdrOk = new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHash, password);
            if (isPwdrOk.In(PasswordVerificationResult.Success, PasswordVerificationResult.SuccessRehashNeeded).Not())
                throw new MeAuthenticateException("Wrong Password");

            // authentication successful
            context.CurrentUserId = user.Id;
            return user;
        }

        public User Create(User user, string password)
        {
            var resultTask = Task.Run(() => userManager.CreateAsync(user, password));
            resultTask.Wait();
            if (resultTask.Result.Succeeded)
            {
                user = context.Users
                    .FirstOrDefault(x => x.NormalizedUserName.Equals(user.NormalizedUserName));
                return user;
            }
            return null;
        }

        public void Delete(Guid id)
        {
            var usr = GetById(id);
            if (usr.IsNotNull())
            {
                var entry = context.Entry<User>(usr);
                entry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
            => context.Users.ToList();

        public User GetById(Guid id)
            => context.Find<User>(id);

        public void Update(User user, string password = null)
        {
            if (password.HasValue().Not())
                return;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, password);
            userManager.UpdateAsync(user).Wait();
        }
    }
}
