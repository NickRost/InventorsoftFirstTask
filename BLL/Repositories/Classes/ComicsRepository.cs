using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories.Classes
{
    class ComicsRepository : IComicsRepository
    {
        public void Add(Comics entity)
        {
            FakeDBContext.Comicses.Add(entity);
        }

        public void Delete(string name)
        {
            var comics = FakeDBContext.Comicses.Where(x => x.Name == name).FirstOrDefault();
            FakeDBContext.Comicses.Remove(comics);
        }

        public void Edit(Comics entity)
        {
            var index = FakeDBContext.Comicses.FindIndex(x => x.Id == entity.Id);
            FakeDBContext.Comicses[index] = entity;
        }

        public Comics FindByName(string name)
        {
            return FakeDBContext.Comicses.FirstOrDefault(x => x.Name == name);
        }

        public List<Comics> FindMany(Expression<Func<Comics, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Comicses.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Comicses;
        }

        public Comics FindOne(Expression<Func<Comics, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Comicses.Where(filter.Compile()).FirstOrDefault();
            }

            return null;
        }

        public List<Comics> GetAll()
        {
            return FakeDBContext.Comicses;
        }
    }
}
