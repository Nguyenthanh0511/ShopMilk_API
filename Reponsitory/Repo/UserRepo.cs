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
    public class TUserRepo : BaseRepo<User> , IUserRepo
    {
        private Shopmilk_5Context _context;
        public TUserRepo(Shopmilk_5Context shop) : base(shop)
        {
            _context = shop;
        }

        public User findUserLogin(User  user)
        {
            return _context.Users.Where(x => x.UUserName == user.UUserName && x.UPassword == user.UPassword).FirstOrDefault();
        }

        public string returnFollowIdRepo(string username)
        {
            string idUser = _context.Users.Where(x => x.UUserName == username).Select(id=>id.UId).FirstOrDefault();
            return idUser;
        }
    }
}