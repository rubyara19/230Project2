namespace _230_4_1
{
    internal class Program
    {

        // monthly average fun
        static double monthlyAverage(double[,] array, int index)
        {
            double monthlyAverage;

            monthlyAverage = (array[index, 0] + array[index, 1] + array[index, 2] + array[index, 3]
            + array[index, 4]) / 5;

            return Math.Round(monthlyAverage, 2);
        }

        // monthly deviation fun

        static double monthlyDeviation(double monthlyAverage)
        {
            double monthlyDeviation = Math.Pow((57.3 - monthlyAverage), 2);

            return Math.Round(monthlyDeviation, 2);

        }

        // quartly deviation fun

        static double quarterlyDeviation(double[] array)
        {
            double quarterlyAve = Math.Round(Math.Pow((57.3 - (array[0] + array[1] + array[2])
                        / 3), 2), 2);

            return quarterlyAve;
        }


        // yearly average fun

        static double yearlyAverage(double[,] array, int index)
        {
            double yearlyTotal = 0;
            for (int i = 0; i < 12; ++i)
            {
                yearlyTotal += array[i, index];
            }

            return Math.Round((yearlyTotal / 12), 2);

        }

        // yearly deviation fun
        static void Main(string[] args)
        {

            string[] monthArray = new string[12];
            double[,] dataArray = new double[12, 5];
            double[] monthlyAverageArray = new double[3];
            int indexCounter = 0;
            // reading from file

            string filePath = "C:\\Users\\piano\\source\\repos\\230Project2\\230-4-1\\trend.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    string[] lineData = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    // single-dimensional array for months
                    monthArray[indexCounter] = lineData[0];

                    // two-dimensional array
                    dataArray[indexCounter, 0] = double.Parse(lineData[1]);
                    dataArray[indexCounter, 1] = double.Parse(lineData[2]);
                    dataArray[indexCounter, 2] = double.Parse(lineData[3]);
                    dataArray[indexCounter, 3] = double.Parse(lineData[4]);
                    dataArray[indexCounter, 4] = double.Parse(lineData[5]);

                    indexCounter += 1;

                }
            }

            Console.WriteLine("                      TREND-SEASONAL-NOISE ANALYSIS\n");
            Console.Write($"{"",-60}");
            Console.Write($"{"Monthly",-10}");
            Console.Write($"{"Monthly",-10}");
            Console.Write($"{"Quarterly\n",-10}");

            Console.Write($"{"",-10}");
            Console.Write($"{"2020",-10}");
            Console.Write($"{"2021",-10}");
            Console.Write($"{"2022",-10}");
            Console.Write($"{"2023",-10}");
            Console.Write($"{"2024",-10}");
            Console.Write($"{"Average",-10}");
            Console.Write($"{"Deviation",-10}");
            Console.Write($"{"Deviation\n\n"}");


            // for loop to run values for monthly + quarterly
            for (int i = 0; i < 12; ++i)
            {
                double monthlyAve = monthlyAverage(dataArray, i);
                double monthlyDev = monthlyDeviation(monthlyAve);
                monthlyAverageArray[i % 3] = monthlyAve;

                // output

                Console.Write($"{monthArray[i],-12}");
                Console.Write($"{dataArray[i, 0],-10}");
                Console.Write($"{dataArray[i, 1],-10}");
                Console.Write($"{dataArray[i, 2],-10}");
                Console.Write($"{dataArray[i, 3],-10}");
                Console.Write($"{dataArray[i, 4],-10}");
                Console.Write($"{monthlyAve,-10}");
                Console.Write($"{monthlyDev,-10}");

                // quarterly values
                if ((i % 3) == 2)
                {

                    Console.Write($"{quarterlyDeviation(monthlyAverageArray),-10}");

                }
                Console.WriteLine("");


            }

            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Yearly");
            Console.Write($"{"Average",-12}");

            double[] yearlyAverageArray = new double[5];

            // for loop to run values for yearly

            for (int j = 0; j < 5; ++j)
            {
                double yearlyAve = yearlyAverage(dataArray, j);
                Console.Write($"{yearlyAve,-10}");
                yearlyAverageArray[j] = yearlyAve;
            }


            Console.WriteLine("\nYearly");
            Console.Write($"{"Deviation",-12}");
            for (int j = 0; j < 5; ++j)
            {
                Console.Write($"{Math.Round(Math.Pow(57.3 - (yearlyAverageArray[j]), 2), 2),-10}");
            }

        }
    }


}
