using Model.Model;
using Reponsitory.Base;
using Reponsitory.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Repo
{
    public class UserRepo : BaseRepo<User> , IUsersRepo
    {
        private Shopmilk_5Context _context;
        public UserRepo(Shopmilk_5Context shop) : base(shop)
        {
            _context = shop;
        }

        public IUsersRepo? findUserLogin(User user)
        {
            return (IUsersRepo?)_context.Users.Where(x => x.UUserName == user.UUserName && x.UPassword == user.UPassword);
        }
    }
}
