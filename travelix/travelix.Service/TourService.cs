using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Repository;

namespace travelix.Service
{
    public class TourService : ITourService
    {
        private readonly IGenericRepository<Tour> _repository;
        public TourService(IGenericRepository<Tour> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Tour> GetAllTour()
        {
            return _repository.GetAll();
        }
        public Tour GetTour(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertTour(Tour tour)
        {
            _repository.Insert(tour);
        }
        public void UpdateTour(Tour tour)
        {
            _repository.Update(tour);
        }
        public void DeleteTour(int id)
        {
            _repository.Delete(id);
        }
    }

}
