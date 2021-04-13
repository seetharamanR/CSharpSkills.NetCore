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
