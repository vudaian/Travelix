using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Repository;

namespace travelix.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Khachhang> _repository;
        public CustomerService(IGenericRepository<Khachhang> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Khachhang> GetAllCustomer()
        {
            return _repository.GetAll();
        }
        public Khachhang GetCustomer(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertCustomer(Khachhang khachhang)
        {
            _repository.Insert(khachhang);
        }
        public void UpdateCustomer(Khachhang khachhang)
        {
            _repository.Update(khachhang);
        }
        public void DeleteCustomer(int id)
        {
            _repository.Delete(id);
        }
    }
}
