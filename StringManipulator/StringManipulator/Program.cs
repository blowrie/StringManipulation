/*Implement a method that takes in a list of strings. Its behavior should be the following for each string:

        a) Reverse the string if its length is a multiple of 4.

        b) Truncate the string to 5 characters if its length is a multiple of 5.

        c) Convert the string to all uppercase if it contains at least 3 uppercase characters in the first 5 characters.

        d) If the string ends with a hyphen, remove it, and append the next string in the list to the current one.

        e) Print the string out.

Additionally, give a final report of the total characters in the input, total characters in the output, and median length of all strings.  
Give this module a name that you think is most descriptive of what it does, while still concise.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> sList = new List<string>();
            string input;
            int count = 0;
            int num1 = 0;

            //End stats variables
            List<int> median = new List<int>();
            int inNum = 0;
            int outNum = 0;
            int finalMed = 0;
            //if length for median is even
            int num2 = 0;


            Console.WriteLine("Please enter a list of strings and type ! when finished");
            do
            {
                input = Console.ReadLine();
                sList.Add(input);
                //This is necessary to make sure that done is not shown within the list
                if (input == "!")
                {
                    sList.Remove(input);
                }
                inNum = inNum + input.Length;
                median.Add(input.Length);
            } while (input != "!");

            Manipulate(sList);

            foreach (string s in sList)
            {

                Console.WriteLine(s);
                outNum = outNum + s.Length;
                median.Add(s.Length);
            }

            median.Sort();
            count = median.Count();
            if (count % 2 == 1)
            {
                num1 = count / 2;
                finalMed = median[num1];
            }
            else
            {
                //this will return low number becuase this int round down
                num1 = count / 2;
                //this will return the high number needed
                num2 = (count / 2) + 1;
                finalMed = (median[num1] + median[num2]) / 2;
            }

            Console.WriteLine("");
            Console.WriteLine("The total number of characters input are: " + inNum);
            Console.WriteLine("The total number of characters output are: " + outNum);
            Console.WriteLine("the median of the string length: " + finalMed);
        }

        static void Manipulate(List<string> myStrings)
        {
            int count = 0;

            for (int i = 0; i < myStrings.Count(); i++)
            {
                string s = myStrings[i];
                int length = s.Length;
                char[] charArray = s.ToCharArray();
                //Part 1
                if (length % 4 == 0)
                {
                    Array.Reverse(charArray);
                    myStrings[i] = new string(charArray);
                }
                //Part 2
                if (length % 5 == 0)
                {
                    myStrings[i] = new string(charArray);
                    myStrings[i] = myStrings[i].Substring(0, 5);
                }

                //Part 3
                foreach (char c in charArray)
                {
                    if (char.IsUpper(c))
                    {
                        count = count + 1;
                        if (count == 3)
                        {
                            myStrings[i] = myStrings[i].ToUpper();
                        }
                    }
                }

                //Part 4
                for (int j = 0; j < charArray.Length; j++)
                {
                    if (charArray[j].Equals('-'))
                    {
                        myStrings[i] = myStrings[i].Substring(0, j) + myStrings[i + 1];

                    }
                }


            }

        }
//End Brackets
    }
}

