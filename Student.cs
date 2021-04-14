using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSkills.NetCore
{
    class Student : Person
    {
        private int[] testScores;

        /*	
        *   Class Constructor
        *   
        *   Parameters: 
        *   firstName - A string denoting the Person's first name.
        *   lastName - A string denoting the Person's last name.
        *   id - An integer denoting the Person's ID number.
        *   scores - An array of integers denoting the Person's test scores.
        */
        // Write your constructor here
        public Student(string firstName, string lastName, int identification, int[] testScores)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = identification;
            this.testScores = testScores;
        }

        /*	
        *   Method Name: Calculate
        *   Return: A character denoting the grade.
        */
        // Write your method here
        public string Calculate()
        {
            string grade = string.Empty;

            int totalScore = 0;
            int AverageScore = 0;

            for (int i = 0; i <= testScores.Length-1; i++)
            {
                totalScore = totalScore + testScores[i];
            }

            //Average 
            AverageScore = totalScore / testScores.Length;

            if (AverageScore < 40)
            {
                grade = "T";
                return grade;
            }
            if (AverageScore <= 40 || AverageScore < 55)
            {
                grade = "D";
                return grade;
            }
            if (AverageScore <= 55 || AverageScore < 70)
            {
                grade = "P";
                return grade;
            }
            if (AverageScore <= 70 || AverageScore < 80)
            {
                grade = "A";
                return grade;
            }
            if (AverageScore >= 80 || AverageScore < 90)
            {
                grade = "E";
                return grade;
            }
            if (AverageScore <= 90 || AverageScore <= 100)
            {
                grade = "O";
                return grade;
            }


            return grade;

        }

    }

}
