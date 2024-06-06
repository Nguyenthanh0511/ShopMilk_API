using Model.Model;
using Reponsitory.IRepo;
using Service.Base;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService: IBaseService<User,UserDto,IUserRepo>
    {
        void LoginUser(User user);
    }
}
