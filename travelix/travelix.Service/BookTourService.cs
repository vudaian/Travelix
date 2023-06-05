using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Repository;

namespace travelix.Service
{
    public class BookTourService : IBookTourService
    {
        private readonly IGenericRepository<Dattour> _repository;
        public BookTourService(IGenericRepository<Dattour> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Dattour> GetAllBookTour()
        {
            return _repository.GetAll();
        }
        public Dattour GetBookTour(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertBookTour(Dattour dattour)
        {
            _repository.Insert(dattour);
        }
        public void UpdateBookTour(Dattour dattour)
        {
            _repository.Update(dattour);
        }
        public void DeleteBookTour(int id)
        {
            _repository.Delete(id);
        }
    }
}
