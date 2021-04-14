using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSkills.NetCore
{
	class Person
	{
		protected string firstName;
		protected string lastName;
		protected int id;

		public Person() { }
		public Person(string firstName, string lastName, int identification)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.id = identification;
		}
		public void printPerson()
		{
			Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
		}
	}
}
