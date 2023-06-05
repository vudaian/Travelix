using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Repository;

namespace travelix.Service
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<Diadiem> _repository;
        public AddressService(IGenericRepository<Diadiem> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Diadiem> GetAllAddress()
        {
            return _repository.GetAll();
        }
        public Diadiem GetAddress(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertAddress(Diadiem diadiem)
        {
            _repository.Insert(diadiem);
        }
        public void UpdateAddress(Diadiem diadiem)
        {
            _repository.Update(diadiem);
        }
        public void DeleteAddress(int id)
        {
            _repository.Delete(id);
        }
    }
}
