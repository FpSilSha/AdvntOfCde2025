using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class DayOne
    {
        

        public void Run()
        {
            try 
            {
                // Pull in the txt of all the rotations and how far they will rotate
                //StreamReader input = new StreamReader("..\\..\\..\\DayOnePuzzleInput.txt");
                StreamReader input = new StreamReader("..\\..\\..\\DayOnePuzzleInput.txt");
                string line;
                int start = 50;
                int currentPlacement = start;
                int countOfZero = 0;
                //For logging purposes
                //int lineNumber = 1;

                // This is fine, we know its only strings
                while ((line = input.ReadLine()) != null)
                {
                    //For logging purposes
                    //Console.WriteLine($"Starting at {currentPlacement} and doing {line}");

                    if ((line.Substring(0, 1)) == "R")
                    {
                        // We know the constraints are X___ at max. There isn't a rotation greater than 999.
                        if (line.Length > 3)
                        {
                            currentPlacement += int.Parse(line.Substring(2));
                        }
                        else
                        {

                            currentPlacement += int.Parse(line.Substring(1));
                        }

                        if (currentPlacement > 99) currentPlacement -= 100;

                    } else
                    {
                        if (line.Length > 3)
                        {
                            currentPlacement -= int.Parse(line.Substring(2));
                        }
                        else
                        {

                            currentPlacement -= int.Parse(line.Substring(1));
                        }

                        // currentPlacement could be negative. So we take 100 and 'add' the negative number it is at to get the abs val.
                        if (currentPlacement < 0) currentPlacement = 100 + currentPlacement;
                    }
                    if (currentPlacement == 0) countOfZero++;
                    //For logging purposes
                    //Console.WriteLine($"Now at {currentPlacement}. Zero counter is {countOfZero}");
                    //Console.WriteLine($"Line used {lineNumber}");
                    //Console.WriteLine("------------------------ \n\n\n\n");
                    //Console.WriteLine(line);
                    //lineNumber++;
                }
                Console.WriteLine(countOfZero);
            } catch (Exception e)
            {
                Console.WriteLine ("There was an issue reading the file! Error: " + e.ToString());
            }
            
        }

        
    }
}
