using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {

            MyMapNode<string, int> myMap = new MyMapNode<string, int>(10);
            string[] Paragraph;
            string input = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            Paragraph = input.Split(' ');
            //Given string input

            int counts = 1;
            foreach (string i in Paragraph)
            {
                counts = myMap.CheckHash(i);
                if (counts > 1)
                {
                    myMap.Add(i, counts);
                }
                else
                {
                    myMap.Add(i, 1);
                }
            }
            Console.WriteLine("Frequency of words in paragraph");
            IEnumerable<string> distinct = Paragraph.Distinct<string>();
            foreach (var i in distinct)
            {
                myMap.Remove("avoidable");
                myMap.Display(i);
            }
            
        }
    }
}