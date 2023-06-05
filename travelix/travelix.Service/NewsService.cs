using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Repository;

namespace travelix.Service
{
    public class NewsService : INewsService
    {
        private readonly IGenericRepository<Tintuc> _repository;
        public NewsService(IGenericRepository<Tintuc> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Tintuc> GetAllNews()
        {
            return _repository.GetAll();
        }
        public Tintuc GetNews(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertNews(Tintuc tintuc)
        {
            _repository.Insert(tintuc);
        }
        public void UpdateNews(Tintuc tintuc)
        {
            _repository.Update(tintuc);
        }
        public void DeleteNews(int id)
        {
            _repository.Delete(id);
        }
    }
}
