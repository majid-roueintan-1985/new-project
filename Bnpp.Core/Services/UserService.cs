using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.Convertors;
using Bnpp.Core.Security;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Context;
using Bnpp.DataLayer.Entities;

namespace Bnpp.Core.Services
{
    public class UserService:IUserService
    {
        private BnppContext _context;

        public UserService(BnppContext context)
        {
            _context = context;
        }
        public User LoginUser(LoginViewModel login)
        {
            //string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
           
            return _context.Users.SingleOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
        }
    }
}
