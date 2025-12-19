using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class DayTwo
    {
        private string _projectPath;
        private const string _challengeTextFileName = "DayTwoPuzzleInput.txt";
        public DayTwo(string projectPath)
        {
            _projectPath = projectPath;
        }

        public void Run()
        {
            
            Dictionary<long, int> sillyIds = new Dictionary<long, int>();
            try
            {
                
                // We know the input is a long string with commas ',' to separate 'ID ranges'
                StreamReader input = new StreamReader(Path.Combine(_projectPath, _challengeTextFileName));
                string[] idRanges = input.ReadLine().Split(',');

                long totalOfIds = 0;
                long doubledNumber = 0;
                int loggingCounter = 0;
                foreach (string idRange in idRanges)
                {
                    Console.WriteLine($"Iteration {loggingCounter} starting.");
                    loggingCounter++;
                    // Skip any ID ranges that are blank/low numbers
                    if (idRange.Length < 3) continue;
                    long upperBound = long.Parse(idRange.Substring(idRange.IndexOf("-") + 1));
                    long lowerBound = long.Parse(idRange.Substring(0,idRange.IndexOf("-")));
                    // This means the range doesn't have repeating numbers possible, so skip ahead.
                    if (upperBound < 11) continue;
                    
                    // I could send the number to startingNumber and parse into lowerbound,
                    // but this is easier to read on the groupings of code.
                    // This checks if all conditions lead to failure, just skip the iteration
                    string startingNumber = lowerBound.ToString();
                    if (startingNumber.Length % 2 != 0 && 
                        upperBound.ToString().Length % 2 != 0 && 
                        upperBound.ToString().Length == startingNumber.Length)
                    {
                            continue;
                    }

                    string numberToCheck = startingNumber.Substring(0, startingNumber.Length/2);
                    if (numberToCheck.Length == 0) numberToCheck = startingNumber;

                    // This bit of code checks if the lowerBound number is an even length
                    // Since we did an upper bound check above, the lowerBound must be able to be incremented to
                    // work with the rest of the solution
                    if (startingNumber.Length % 2 != 0)
                    {
                        
                        while (numberToCheck.Length % 2 != 0)
                        {
                            numberToCheck = IncrementStringInt64(numberToCheck);
                        }
                        numberToCheck = numberToCheck.Substring(0, numberToCheck.Length/2);
                    }

                    while ((doubledNumber <= upperBound) && (long.Parse(numberToCheck) <= upperBound)) //long.Parse(numberToCheck) <= upperBound
                    {
                        
                        // Parse the string into an int and check if its still within upper bound range and lower bound range.
                        doubledNumber = long.Parse((numberToCheck + numberToCheck));
                        // Skip loop cases
                        if (doubledNumber < lowerBound)
                        {
                            numberToCheck = IncrementStringInt64(numberToCheck);
                            continue;
                        }
                        
                        if (doubledNumber > upperBound) continue;
                        // Should be within bounds
                        
                        totalOfIds += doubledNumber;
                        sillyIds.Add(doubledNumber, loggingCounter);
                        numberToCheck = IncrementStringInt64(numberToCheck);


                    }
                        
                    doubledNumber = 0;
                    
                }

                Console.WriteLine($"The password is: {totalOfIds}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error reading the file! {e.ToString()}");
            }

            foreach (KeyValuePair<long,int> kvp in sillyIds)
            {
                Console.WriteLine($"The range at {kvp.Value} includes {kvp.Key}");
            }
            Console.WriteLine(sillyIds.Count);
        }

        private string IncrementStringInt64(string numberToIncrement)
        {
            long result;
            bool success = long.TryParse(numberToIncrement, out result);

            if (success)
            {
                result++;
                return result.ToString();
            }

            Console.WriteLine($"Parsing of {numberToIncrement} failed, number not incremented.");
            return numberToIncrement;
             
        }


    }
}
