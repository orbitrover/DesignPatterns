using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    /// <summary>
    /// Client Code
    /// </summary>
    public static class BookshelfService
    {
        public static void Run()
        {
            var shelf = new Bookshelf();
            shelf.Add(new Book("C#.NET", "Pranaya Rout"));
            shelf.Add(new Book("ASP.NET Core", "Prateek Sahoo"));
            shelf.Add(new Book("Entity Framework", "Hina Sharma"));
            var iterator = shelf.CreateIterator();
            while (iterator.HasNext())
            {
                var book = iterator.Next();
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
            
        }
    }
    //Define the Book
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
    
    
    //Implement a concrete aggregate, Bookshelf, and its iterator
    public class Bookshelf : INextAggregate<Book>
    {
        private List<Book> _books = new List<Book>();
        public void Add(Book book)
        {
            _books.Add(book);
        }
        public INextIterator<Book> CreateIterator()
        {
            return new BookshelfIterator(this);
        }
        private class BookshelfIterator : INextIterator<Book>
        {
            private Bookshelf _bookshelf;
            private int _currentIndex = 0;
            public BookshelfIterator(Bookshelf bookshelf)
            {
                _bookshelf = bookshelf;
            }
            public bool HasNext()
            {
                return _currentIndex < _bookshelf._books.Count;
            }
            public Book Next()
            {
                return _bookshelf._books[_currentIndex++];
            }
        }
    }
}
