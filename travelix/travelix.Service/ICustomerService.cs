using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Service
{
    public interface ICustomerService
    {
        IEnumerable<Khachhang> GetAllCustomer();
        Khachhang GetCustomer(int id);
        void InsertCustomer(Khachhang khachHang);
        void UpdateCustomer(Khachhang khachHang);
        void DeleteCustomer(int id);
    }
}
