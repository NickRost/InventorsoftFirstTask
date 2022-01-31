using BLL.Managers.Interfaces;
using BLL.Services.Classes;
using BLL.Services.Interfaces;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ComicsShop
{
    public class ComicsShopMethods
    {
        private readonly IAuthorService authorService;
        private readonly IComicsService comicsService;
        private readonly ITagService tagService;


        public ComicsShopMethods()
        {
            authorService = new AuthorService();
            comicsService = new ComicsService();
            tagService = new TagService();
        }

        public void AddItems()
        {
            AddAuthors();
            AddComicses();
            AddTags();

        }

        public void AddAuthors()
        {
            var author = new Author { FirstName = "Frank", LastName = "Waid", CreationDate = DateTime.Now, BirthDate = DateTimeRandom.RandomDay() };
            var author1 = new Author { FirstName = "Mark", LastName = "Smith", CreationDate = DateTime.Now, BirthDate = DateTimeRandom.RandomDay() };
            var author2 = new Author { FirstName = "Jack", LastName = "Miller", CreationDate = DateTime.Now, BirthDate = DateTimeRandom.RandomDay() };
            var author3 = new Author { FirstName = "Joe", LastName = "Einstein", CreationDate = DateTime.Now, BirthDate = DateTimeRandom.RandomDay() };
            var author4 = new Author { FirstName = "John", LastName = "Miller", CreationDate = DateTime.Now, BirthDate = DateTimeRandom.RandomDay() };

            authorService.AddAuthor(author);
            authorService.AddAuthor(author1);
            authorService.AddAuthor(author2);
            authorService.AddAuthor(author3);
            authorService.AddAuthor(author4);
        }

        public void AddComicses()
        {
            var comics = new Comics { Name = "Spider-man", Order = 1, Pages = 28, IsSpecial = true, PublishingHouse = PublishingHouse.Marvel, CreationDate = DateTimeRandom.RandomDay() };
            var comics1 = new Comics { Name = "Spider-man", Order = 2, Pages = 26, PublishingHouse = PublishingHouse.Marvel, CreationDate = DateTimeRandom.RandomDay() };
            var comics2 = new Comics { Name = "Spider-man", Order = 3, Pages = 29, PublishingHouse = PublishingHouse.Marvel, CreationDate = DateTimeRandom.RandomDay() };
            var comics3 = new Comics { Name = "Spider-man", Order = 4, Pages = 22, PublishingHouse = PublishingHouse.Marvel, CreationDate = DateTimeRandom.RandomDay() };
            var comics4 = new Comics { Name = "Hulk", Order = 5, Pages = 21, IsSpecial = true, PublishingHouse = PublishingHouse.Marvel, CreationDate = DateTimeRandom.RandomDay() };

            comicsService.AddComics(comics);
            comicsService.AddComics(comics1);
            comicsService.AddComics(comics2);
            comicsService.AddComics(comics3);
            comicsService.AddComics(comics4);
        }

        public void AddTags()
        {
            var tag = new Tag { Name = "Galaxy" };
            var tag1 = new Tag { Name = "Tree" };
            var tag2 = new Tag { Name = "Snake" };
            var tag3 = new Tag { Name = "Monkey" };
            var tag4 = new Tag { Name = "Angel" };

            tagService.AddTag(tag);
            tagService.AddTag(tag1);
            tagService.AddTag(tag2);
            tagService.AddTag(tag3);
            tagService.AddTag(tag4);

        }

        public List<Comics> FindSpecialComics()
        {
            return comicsService.FindManyComicses(x => x.IsSpecial == true);
        }

        public List<Comics> FindDCComics()
        {
            return comicsService.FindManyComicses(x => x.PublishingHouse == Domain.Enums.PublishingHouse.DC);
        }

        public List<Comics> FindOldComics()
        {
            DateTime date = new DateTime(1950, 1, 1);
            return comicsService.FindManyComicses(x => x.CreationDate < date);
        }

        public List<Author> FindOldAuthors()
        {
            return authorService.FindManyAuthors(x => (DateTime.Now.Year - x.BirthDate.Year) > 52);
        }

        public Author FindOldestAuthor()
        {
            return authorService.GetAllAuthors().OrderBy(x => x.BirthDate).FirstOrDefault();
        }

        public Author FindYoungestAuthor()
        {
            return authorService.GetAllAuthors().OrderByDescending(x => x.BirthDate).FirstOrDefault();
        }

        public List<Tag> FindNewTags()
        {
            return tagService.FindManyTags(x => x.Name == "New");
        }

        public List<Tag> FindSaleTags()
        {
            return tagService.FindManyTags(x => x.Name == "Sale");
        }

        public List<Tag> FindCommonTags()
        {
            return tagService.FindManyTags(x => x.Name == "Common");
        }

        public void DeleteAngelTag()
        {
            tagService.DeleteTag("Angel");
        }

        public void DeleteHulkComics()
        {
            comicsService.DeleteComics("Hulk");
        }

        public void DeleteAuthor()
        {
            authorService.DeleteAuthor("Frank Waid");
        }

        public void EditAngelTag()
        {
            var angel = tagService.GetTagByName("Angel");
            angel.Name= "Angel Edited";
            tagService.EditTag(angel); 
        }

        public void EditHulkComics()
        {
            var hulk = comicsService.GetComicsByName("Hulk");
            hulk.Name = "Hulk Edited";
            comicsService.EditComics(hulk);
        }

        public void EditAuthor()
        {
            var author = authorService.GetAuthorByName("Frank Miller");
            author.LastName = "Miller (edited)";
            authorService.EditAuthor(author);
        }
    }
}
