using AutoMapper;
using Model.Model;
using Reponsitory.IRepo;
using Reponsitory.Repo;
using Service.Base;
using Service.Dto;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class UserService : BaseService<User,UserDto,IUserRepo>,IUserService
    {
        private readonly Shopmilk_5Context _context;
        public UserService(IUserRepo trepo, IMapper _map) : base(trepo, _map)
        {
        }

        public void LoginUser(User user)
        {
            try
            {
                this.ObjDetail = ThisRepo.findUserLogin(user);
            }catch(Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

    }
}
