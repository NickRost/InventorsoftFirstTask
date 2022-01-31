using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Repositories.Classes
{
    public class TagRepository : ITagRepository
    {
        public void Add(Tag entity)
        {
            FakeDBContext.Tags.Add(entity);
        }

        public void Delete(string name)
        {
            var tag = FakeDBContext.Tags.Where(x => x.Name == name).FirstOrDefault();
            FakeDBContext.Tags.Remove(tag);
        }

        
        public void Edit(Tag entity)
        {
            var index = FakeDBContext.Tags.FindIndex(x => x.Id == entity.Id); // тут не знав як краще редагувати
            FakeDBContext.Tags[index] = entity;
        }

        
        public Tag FindByName(string name)
        {
            return FakeDBContext.Tags.FirstOrDefault(x=>x.Name == name);
        }

        // ToDo
        public List<Tag> FindMany(Expression<Func<Tag, bool>> filter = null)
        {
            if ( filter!= null )
            {
                return FakeDBContext.Tags.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Tags;
        }

        // ToDo
        public Tag FindOne(Expression<Func<Tag, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Tags.Where(filter.Compile()).FirstOrDefault();
            }

            return null;
        }

        
        public List<Tag> GetAll()
        {
            return FakeDBContext.Tags;
        }
    }
}
