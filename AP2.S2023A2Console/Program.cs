using System.Text.Json;

namespace AP2.S2023A2Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ComeLeave> entry = LoadComeLeaveDataFromMockJson();

            // v1
            int[,] visitorsArray = countVisitors(entry);
            PrintArrayToConsole(visitorsArray);

            // v2
            Console.WriteLine("\n\nVersion 2 (Bube) \n");

            int[,] visitorsArrayV2 = countVisitorsV2(entry);
            PrintArrayToConsole(visitorsArrayV2);

            Console.WriteLine("\nPress [ENTER] to exit...");
            Console.ReadLine();
        }

        private static int[,] countVisitors(List<ComeLeave> entry)
        {
            int days = entry[0].getDate().getDaysOfMonth();
            int[,] visitors = new int[days, 10];

            for (int i = 0; i < days; i++)
            {
                for (int t = 0; t < 10; t++)
                {
                    foreach (ComeLeave e in entry)
                    {
                        if (e.getDate().getDay() == i + 1 && e.getDate().getHour() == t + 9)
                        {
                            if (e.getComeInOut() == 0)
                            {
                                visitors[i, t] += e.getNoPeople();
                            }
                            else
                            {
                                if (t < 9)
                                    visitors[i, t + 1] -= e.getNoPeople();
                            }
                        }
                    }

                    if (t > 0)
                    {
                        visitors[i, t] += visitors[i, t - 1];
                    }
                }
            }

            return visitors;
        }

        private static int[,] countVisitorsV2(List<ComeLeave> entry)
        {
            int days = entry[0].getDate().getDaysOfMonth();
            int[,] visitors = new int[days, 10];

            foreach (ComeLeave e in entry)
            {
                int row = e.getDate().getDay() - 1;
                int col = e.getDate().getHour() - 9;

                for (int i = col; i < 10; i++)
                {
                    if (e.getComeInOut() == 0)
                    {
                        visitors[row, i] += e.getNoPeople();
                    }
                    else
                    {
                        if (i < 9) 
                            visitors[row, i + 1] -= e.getNoPeople();
                    }
                }
            }

            return visitors;
        }

        private static List<ComeLeave> LoadComeLeaveDataFromMockJson()
        {
            string jsonFile = File.ReadAllText("ComeLeaveMockData.json");
            return JsonSerializer.Deserialize<List<ComeLeave>>(jsonFile)!;
        }

        private static void PrintArrayToConsole(int[,] visitorsArray)
        {
            for (var i = -1; i < visitorsArray.GetLength(0); i++)
            {
                if (i == -1)
                    Console.Write($" day/h |");
                else
                    Console.Write($" {i + 1,4}  |");

                for (var j = 0; j < visitorsArray.GetLength(1); j++)
                {
                    if (i == -1)
                        Console.Write($"{j + 9,4} |");
                    else
                        Console.Write($"{visitorsArray[i, j],4} |");
                }

                Console.WriteLine();
                if (i == -1)
                {
                    Console.WriteLine("--------------------------------------------------------------------");
                }
            }
        }
    }
}
