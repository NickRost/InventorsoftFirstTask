using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    interface IComicsService
    {
        Comics GetComicsByName(string name);

        void DeleteComics(string comicsName);

        void EditComics(Comics comics);

        List<Comics> GetAllComicses();

        Comics FindOneComics(Expression<Func<Comics, bool>> filter = null);

        List<Comics> FindManyComicses(Expression<Func<Comics, bool>> filter = null);
    }
}
