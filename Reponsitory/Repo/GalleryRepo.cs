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
    public class GalleryRepo : BaseRepo<Gallery>, IGalleryRepo
    {
        public GalleryRepo(Shopmilk_5Context shop) : base(shop)
        {
        }
    }
}
