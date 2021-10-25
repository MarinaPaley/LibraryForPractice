namespace LibraryDemo
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            var author = new Domain.Author(1, "Носов","Николай");
            var book = new Domain.Book(1, "Незнайка", author);

            Console.WriteLine($"{book} {author}");
        }
    }
}
