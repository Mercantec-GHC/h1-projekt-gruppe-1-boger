using Domain_Models.Webshop.Medias;
using Domain_Models.Webshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Models.Enums;
using Domain_Models.Database;

namespace ParseData
{
    public class FetchDB
    {
        public List<Book> ParseBooks(string path)
        {
            var books = new List<Book>();
            var lines = ReadFile(path);

            lines.ForEach(line =>
            {
                
                var bookLines = SplitLine(line);
                var book = Creator(bookLines);
                books.Add(book);
            });

            return books;
        }
        public List<string> ReadFile(string fileName)
        {
            return File.ReadLines(fileName).ToList();
        }

        private List<string> SplitLine(string line, char sep = '\t')
        {
            return line.Split(sep).ToList();
        }
        public List<Tag> CreateTags(string tagString, char sep = ',')
        {
            var tagNames = tagString.Split(sep).ToList();
            var tags = new List<Tag>();
            foreach (var tag in tagNames)
            {
                tags.Add(new Tag { Name = tag });
            }
            return tags;
        }
        private Book Creator(List<string> columns)
        {
            var language = new Dictionary<string, Enum>();
            language.Add("English", Domain_Models.Enums.LANGUAGE.ENGLISH);
            language.Add("Swedish", Domain_Models.Enums.LANGUAGE.SWEDISH);
            language.Add("Spanish", Domain_Models.Enums.LANGUAGE.SPANISH);
            language.Add("Japanese", Domain_Models.Enums.LANGUAGE.JAPANESE);
            language.Add("Danish", Domain_Models.Enums.LANGUAGE.DANISH);
            language.Add("Portuguese", Domain_Models.Enums.LANGUAGE.PORTUGUESE);

            var gerne = new Dictionary<string, Enum>();
            gerne.Add("Fantasy", Domain_Models.Enums.GENRE.FANTASY);
            gerne.Add("Mystery", Domain_Models.Enums.GENRE.MYSTERY);
            gerne.Add("Science Fiction", Domain_Models.Enums.GENRE.SCIFI);
            gerne.Add("Fiction", Domain_Models.Enums.GENRE.FICTION);
            gerne.Add("Thriller", Domain_Models.Enums.GENRE.THRILLER);
            gerne.Add("Romance", Domain_Models.Enums.GENRE.ROMANCE);
            gerne.Add("History", Domain_Models.Enums.GENRE.HISTORY);
            gerne.Add("Self Development", Domain_Models.Enums.GENRE.SELFDEVELOPMENT);
            gerne.Add("Physics", Domain_Models.Enums.GENRE.PHYSICS);
            gerne.Add("Home", Domain_Models.Enums.GENRE.HOMEANDGARDEN);
            gerne.Add("Epic poetry", Domain_Models.Enums.GENRE.EPICPOETRY);
            gerne.Add("Novel", Domain_Models.Enums.GENRE.NOVEL);
            gerne.Add("Tragedy", Domain_Models.Enums.GENRE.TRAGEDY);
            gerne.Add("Comedy", Domain_Models.Enums.GENRE.COMEDY);
            gerne.Add("Bestseller", Domain_Models.Enums.GENRE.BESTSELLER);
            gerne.Add("Children", Domain_Models.Enums.GENRE.CHILDREN);
            gerne.Add("Classics", Domain_Models.Enums.GENRE.CLASSICS);
            gerne.Add("Drama", Domain_Models.Enums.GENRE.DRAMA);
            gerne.Add("Horror", Domain_Models.Enums.GENRE.HORROR);
            gerne.Add("Nonfiction", Domain_Models.Enums.GENRE.NONFICTION);
            gerne.Add("Science", Domain_Models.Enums.GENRE.SCIENCE);


            var book = new Book();
            book.Title = columns[0];
            book.Author = columns[1];
            book.Pages = int.Parse(columns[2]);
            book.Year = int.Parse(columns[3]);
            book.Language = (Domain_Models.Enums.LANGUAGE)language[columns[4]];
            book.Genre = (Domain_Models.Enums.GENRE)gerne[columns[5]];
            book.Tags = CreateTags(columns[6]);
            book.Description = columns[7];
            book.Price = float.Parse(columns[9]);

            
            return book;
        }
    }
}
