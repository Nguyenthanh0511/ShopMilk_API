using Model.Model;
using Reponsitory.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.IRepo
{
    public interface IUserRepo:IBaseRepo<User>
    {
        public User findUserLogin(User user);
        public string returnFollowIdRepo(string username);
    }
}