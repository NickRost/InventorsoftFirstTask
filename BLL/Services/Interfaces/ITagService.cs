using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Managers.Interfaces
{
    public interface ITagService
    {
        void AddTag(Tag tag);

        Tag GetTagByName(string name);

        void DeleteTag(string tagName);

        void EditTag(Tag tag);

        List<Tag> GetAllTags();

        Tag FindOneTag(Expression<Func<Tag, bool>> filter = null);

        List<Tag> FindManyTags(Expression<Func<Tag, bool>> filter = null);

        //todo: Create Another Methods
    }
}
