using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
   
    class Program
    {
       static void Main(string[] args)
        {
            Console.WriteLine("Enter file path:");
            string filePath = Console.ReadLine();

            ContactManager cm = new ContactManager(filePath);
            Console.WriteLine("\nEntries:");
            foreach(ContactEntry ce in cm.Entries)
            {
                Console.WriteLine(ce.ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        
    }
}
