using BLL.Managers.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using BLL.Services.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Services.Classes
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;

        public TagService() // test commit
        {
            tagRepository = new TagRepository();
        }

        public void AddTag(Tag tag)
        {
            tagRepository.Add(tag);
        }

        public void DeleteTag(string tagName)
        {
            tagRepository.Delete(tagName);
        }

        public void EditTag(Tag tag)
        {
            tagRepository.Edit(tag);
        }

        public List<Tag> FindManyTags(Expression<Func<Tag, bool>> filter = null)
        {
            return tagRepository.FindMany(filter);
        }

        public Tag FindOneTag(Expression<Func<Tag, bool>> filter = null)
        {
            return tagRepository.FindOne(filter);
        }

        public List<Tag> GetAllTags()
        {
            return tagRepository.GetAll();
        }

        public Tag GetTagByName(string name)
        {
            return tagRepository.FindByName(name);
        }
    }
}
