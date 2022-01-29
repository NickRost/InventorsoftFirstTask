﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    interface IAuthorService
    {
        Author GetAuthorByName(string name);

        void DeleteAuthor(string comicsName);

        void EditAuthor(Author comics);

        List<Author> GetAllAuthors();

        Author FindOneAuthor(Expression<Func<Author, bool>> filter = null);

        List<Author> FindManyAuthors(Expression<Func<Author, bool>> filter = null);
    }
}