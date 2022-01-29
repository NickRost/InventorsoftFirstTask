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
    class AuthorRepository : IAuthorRepository
    {
        public void Add(Author entity)
        {
            FakeDBContext.Authors.Add(entity);
        }

        public void Delete(string name)
        {
            var author = FakeDBContext.Authors.Where(x => x.FirstName == name).FirstOrDefault();
            FakeDBContext.Authors.Remove(author);
        }

        public void Edit(Author entity)
        {
            var index = FakeDBContext.Authors.FindIndex(x => x.Id == entity.Id);
            FakeDBContext.Authors[index] = entity;
        }

        public Author FindByName(string name)
        {
            return FakeDBContext.Authors.FirstOrDefault(x => x.FirstName + " " + x.LastName == name);
        }

        public List<Author> FindMany(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Authors.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Authors;
        }

        public Author FindOne(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Authors.Where(filter.Compile()).FirstOrDefault();
            }

            return null;
        }

        public List<Author> GetAll()
        {
            return FakeDBContext.Authors;
        }
    }
}
