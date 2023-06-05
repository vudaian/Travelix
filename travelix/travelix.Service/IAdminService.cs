using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Service
{
    public interface IAdminService
    {
        Quanly GetAdmin(int id);
        void UpdateAdmin(Quanly quanly);
    }
}
