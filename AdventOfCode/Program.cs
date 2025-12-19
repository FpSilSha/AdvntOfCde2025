namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string projectPath = Directory.GetCurrentDirectory();

            //DayOne dayOne = new DayOne(projectPath);
            //dayOne.Run();

            DayTwo dayTwo = new DayTwo(projectPath);
            dayTwo.Run();
            
            Console.ReadKey();
            

        }
    }
}
