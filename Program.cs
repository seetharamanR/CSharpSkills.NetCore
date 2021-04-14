using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSkills.NetCore
{

    class Program
    {
        static void Main(string[] args)
        {
           

            //Abstract
            String title = Console.ReadLine();
            String author = Console.ReadLine();
            int price = Int32.Parse(Console.ReadLine());
            Book new_novel = new MyBook(title, author, price);
            new_novel.display();


            //Inheritance
            string[] inputs = Console.ReadLine().Split();
            string firstName = inputs[0];
            string lastName = inputs[1];
            int id = Convert.ToInt32(inputs[2]);
            int numScores = Convert.ToInt32(Console.ReadLine());
            inputs = Console.ReadLine().Split();
            int[] scores = new int[numScores];
            for (int i = 0; i < numScores; i++)
            {
                scores[i] = Convert.ToInt32(inputs[i]);
            }

            Student s = new Student(firstName, lastName, id, scores);
            s.printPerson();
            Console.WriteLine("Grade: " + s.Calculate() + "\n");


            //Binary Number
            int n = Convert.ToInt32(Console.ReadLine());
            var b = Convert.ToString(n, 2);
            string[] arr = b.Split('0').ToArray();
            int c = arr.Select(x => x.Length).Max();
            Console.WriteLine(c);
            //Logic Ends for Binary Conversion

            Factorial.FindFactorial();
            DictionaryImplement.DictionaryFind();
            DictionaryImplement.DictionaryMap();
            
            EvenOddArrayFormator.FormatArray(args);
        }
    }

}
