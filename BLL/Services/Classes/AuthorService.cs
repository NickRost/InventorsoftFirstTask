using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using BLL.Services.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        public void AddAuthor(Author author)
        {
            authorRepository.Add(author);
        }

        public void DeleteAuthor(string authorName)
        {
            authorRepository.Delete(authorName);
        }

        public void EditAuthor(Author author)
        {
            authorRepository.Edit(author);
        }

        public List<Author> FindManyAuthors(Expression<Func<Author, bool>> filter = null)
        {
            return authorRepository.FindMany(filter);
        }

        public Author FindOneAuthor(Expression<Func<Author, bool>> filter = null)
        {
            return authorRepository.FindOne(filter);
        }

        public List<Author> GetAllAuthors()
        {
            return authorRepository.GetAll();
        }

        public Author GetAuthorByName(string name)
        {
            return authorRepository.FindByName(name);
        }
    }
}
