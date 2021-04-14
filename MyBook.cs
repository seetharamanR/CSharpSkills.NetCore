using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSkills.NetCore
{
    public class MyBook : Book
    {
        int price = 0;

        public MyBook(string title,string author, int price) : base(title, author)
        {
            this.price = price;
        }

        public override void display()
        {
            Console.Write("Title: {0} \nAuthor: {1} \nPrice: {2}", title, author, price);
        }
    }
}
