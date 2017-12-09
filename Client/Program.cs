using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Book myBook = new Book()
            {
                Author = new Author()
                { FirstName = "Эндрю", LastName = "Троелсен"},
                Name = "C# 5.0",
                ISBN = "12345X"
            };


            //BinaryFormatter binFormatter = new BinaryFormatter();
            //XmlSerializer xmlFormatter = new XmlSerializer(myBook.GetType());

            JsonSerializer jsonSerializer = new JsonSerializer();

            string jsonSerilized = JsonConvert.SerializeObject(myBook);

            File.WriteAllText("book.json", jsonSerilized);

            FileInfo fi = new FileInfo("book.json");
            using (StreamReader streamReader = fi.OpenText())
            {
                string jsonData = streamReader.ReadToEnd();
                var res = JsonConvert.DeserializeObject<Book>(jsonData);
            }

            //using (FileStream fs = new FileStream("book.xml", FileMode.Create))
            //{
            //    xmlFormatter.Serialize(fs, myBook);
            //}

            //using (FileStream fs = new FileStream("book.xml", FileMode.Open))
            //{
            //    var res = (Book)xmlFormatter.Deserialize(fs);


            //}

            //using (FileStream fs = new FileStream("book.dat", FileMode.Create))
            //{
            //    binFormatter.Serialize(fs, myBook);
            //}


            //using (FileStream fs = new FileStream("book.dat", FileMode.Open))
            //{
            //    object resObj = binFormatter.Deserialize(fs);

            //    if (resObj is Book)
            //    {
            //        var resBook = resObj as Book;
            //    }
            //}


            Console.ReadLine();
        }
    }
}
