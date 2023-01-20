using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNITOFWORK_AND_REPOSITORY_PATTERN.Entities;

namespace UNITOFWORK_AND_REPOSITORY_PATTERN
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new MyDbContext("{connectionString goes here}");
            var unitOfWork = new UnitOfWork(dbContext);

            // Selecting some entities
            var books = unitOfWork.BookRepository.Entities
                .Where(n => n.Title == "Hello World");
            var justOneBook = unitOfWork.BookRepository.Entities
                .First(n => n.ID == 1);

            // Create
            var author = new Author() { Name = "Kris" };
            unitOfWork.AuthorRepository.Add(author);
            unitOfWork.Commit(); // Save changes to database

            // Update
            author = unitOfWork.AuthorRepository.Entities
                .First(n => n.Name == "Kris");
            author.Name = "Dan";
            unitOfWork.Commit(); // Save changes to database

            // Delete
            author = unitOfWork.AuthorRepository.Entities
                .First(n => n.Name == "Dan");
            unitOfWork.AuthorRepository.Remove(author);
            unitOfWork.Commit(); // Save changes to database

            // Delete
            author = unitOfWork.AuthorRepository.Entities
                .First(n => n.Name == "Dan");
            unitOfWork.AuthorRepository.Remove(author);
            // Ops i don't want to do this
            unitOfWork.RejectChanges(); // Reject all changes

            Console.ReadKey();
        }
    }
}
