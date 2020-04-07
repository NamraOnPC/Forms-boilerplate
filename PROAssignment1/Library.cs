using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PROAssignment1
{
    /*
     * Class Library has three data members libraryID , Address of the Library and List of Books the library has.
     */
    public class Library
    {
        public int _libraryID { get; set; }

        public String _address { get; set; }

        // Initialises a list of Book objects.
        List<Book> _books = new List<Book>();

        /*
         * Recieves a string of data from csv file.
         * An array of string values is made by splitting the csv data.
         * New library object is initialized.
         * The values stored in the array are assigned to the data members of the library object.
         * Returns library object
         */
        public static Library FromCsv(string csvLine)
        {
            string[] values = csvLine.Split('|');
            Library library = new Library();
            library._libraryID = Convert.ToInt32(values[0]);
            library._address = values[1];
                /*
                 * Assigns data to a List of Book objects by reading all the lines from Book.csv file.
                 * The first line of the file is skipped because of the headers.
                 * It passes the collected string data from the csv file to the FromCsv() function in Book Class.
                 * All the book objects are sorted based on their title.
                 * The manipulated data is then converted to a list.
                 */
            library._books = File.ReadAllLines("..\\..\\Book.csv")
                                               .Skip(1)
                                               .Select(v => Book.FromCsv(v))
                                               .OrderBy(o => o._title)
                                               .ToList();
                                              
            return library;
        }
        
        /*
         * Class Book has five data members bookID , Summary of the book , Title of the book , address of the library the book can be found at and corresponding libraryID.
         */
        public class Book
        {
            public int _bookID { get; set; }

            public String _summary { get; set; }

            public String _title { get; set; }

            public String _libraryAddress { get; set; }

            public int _libraryID { get; set; }

             /*
              * Recieves a string of data from csv file.
              * An array of string values is made by splitting the csv data.
              * New Book object is initialized.
              * The values stored in the array are assigned to the data members of the Book object.
              * Returns Book object
              */
            public static Book FromCsv(string csvLine)
            {
                string[] values = csvLine.Split('|');
                Book book = new Book();
                book._bookID = Convert.ToInt32(values[0]);
                book._summary = values[1];
                book._title = values[2];
                book._libraryAddress = values[3];
                book._libraryID = Convert.ToInt32(values[4]);
                return book;
            }
        }

        class Program
        {
            static void Main(String[] args)
            {
                /*
                 * Initialises a List of Library objects by reading all the lines from library.csv file.
                 * The first line of the file is skipped because of the headers.
                 * It passes the collected string data from the csv file to the FromCsv() function in Library Class.
                 * The manipulated data the function returns is then converted to a list.
                 */
                List<Library> libraryValues = File.ReadAllLines("..\\..\\library.csv")
                                              .Skip(1)
                                              .Select(v => Library.FromCsv(v))
                                              .ToList();

                Console.WriteLine("List of Libraries in the City of Toronto and all the books that are in the library");
                Console.WriteLine(System.Environment.NewLine);

                // Traverses through the list of libraries and prints information about the library
                foreach (Library l in libraryValues)
                {
                    Console.WriteLine($"Library ID: {l._libraryID} Library Address: {l._address}");
                    Console.WriteLine(System.Environment.NewLine);
                   // Traverses through the list of books inside the libraries and prints information about the books( the books are ordered by their title )
                    foreach (Book b in l._books)
                    {
                        // Checks in order to keep the Books in their respective library
                        if (l._libraryID == b._libraryID)
                        {
                            Console.WriteLine($"Book ID: {b._bookID}");
                            Console.WriteLine($"Book Summary: {b._summary}");
                            Console.WriteLine($"Book Title: {b._title}");
                            Console.WriteLine($"Book Library Address: {b._libraryAddress}");
                            Console.WriteLine($"Book Library Id: {b._libraryID}");
                            Console.WriteLine(System.Environment.NewLine);
                        }
                    }
                }
                // Waits for the user to press a key to end the program
                Console.ReadKey();
            }
        }
    }
}