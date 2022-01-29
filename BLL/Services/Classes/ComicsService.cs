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
    public class ComicsService : IComicsService
    {
        private readonly IComicsRepository comicsRepository;
        private readonly IAuthorService authorService;

        public ComicsService()
        {
            comicsRepository = new ComicsRepository();
            authorService = new AuthorService();
        }

        public void AddComics(Comics comics)
        {
            comicsRepository.Add(comics);

            if (comics.Author != null)
            {
                var author = authorService.GetAuthorByName(comics.Author.FirstName + " " + comics.Author.LastName);
                if (author == null)
                {
                    authorService.AddAuthor(comics.Author);
                }
            }
        }

        public void DeleteComics(string comicsName)
        {
            comicsRepository.Delete(comicsName);
        }

        public void EditComics(Comics comics)
        {
            comicsRepository.Edit(comics);
        }

        public List<Comics> FindManyComicses(Expression<Func<Comics, bool>> filter = null)
        {
            return comicsRepository.FindMany(filter);
        }

        public Comics FindOneComics(Expression<Func<Comics, bool>> filter = null)
        {
            return comicsRepository.FindOne(filter);
        }

        public List<Comics> GetAllComicses()
        {
            return comicsRepository.GetAll();
        }

        public Comics GetComicsByName(string name)
        {
            return comicsRepository.FindByName(name);
        }
    }
}
