using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Service
{
    public interface IAddressService
    {
        IEnumerable<Diadiem> GetAllAddress();
        Diadiem GetAddress(int id);
        void InsertAddress(Diadiem diadiem);
        void UpdateAddress(Diadiem diadiem);
        void DeleteAddress(int id);
    }
}
