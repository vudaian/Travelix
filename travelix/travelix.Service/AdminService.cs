using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Repository;

namespace travelix.Service
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository<Quanly> _repository;
        public AdminService(IGenericRepository<Quanly> repository)
        {
            _repository = repository;
        }

        public Quanly GetAdmin(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateAdmin(Quanly quanly)
        {
            _repository.Update(quanly);
        }
    }
}
