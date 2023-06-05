using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Service
{
    public interface IBookTourService
    {
        IEnumerable<Dattour> GetAllBookTour();
        Dattour GetBookTour(int id);
        void InsertBookTour(Dattour dattour);
        void UpdateBookTour(Dattour dattour);
        void DeleteBookTour(int id);
    }
}
