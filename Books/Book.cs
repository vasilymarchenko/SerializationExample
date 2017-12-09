using System;

namespace Books
{
    [Serializable]
    public class Book
    {
        public Author Author { get; set; }

        public string Name;

        public string ISBN;

        public void Do()
        {
            //
        }
    }


    public class Author
    {
        public string FirstName;
        public string LastName;
    }
}
