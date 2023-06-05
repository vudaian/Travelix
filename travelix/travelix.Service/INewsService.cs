using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Service
{
    public interface INewsService
    {
        IEnumerable<Tintuc> GetAllNews();
        Tintuc GetNews(int id);
        void InsertNews(Tintuc tintuc);
        void UpdateNews(Tintuc tintuc);
        void DeleteNews(int id);
    }
}
