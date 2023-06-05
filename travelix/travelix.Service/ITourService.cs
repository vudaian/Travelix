using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Service
{
    public interface ITourService
    {
        IEnumerable<Tour> GetAllTour();
        Tour GetTour(int id);
        void InsertTour(Tour tour);
        void UpdateTour(Tour tour);
        void DeleteTour(int id);
    }
}
