using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoinFlip
{
    class Program
    {
        static int _startingCoins = 1000;
        static int _battlePoints = 0;
        static int _winProbability = 57;
        static int _betAmount = 50;        

        static void Main(string[] args)
        {
            Random rand = new Random();
            int averagePoints = 0;
            int minPoints = 0;
            int maxPoints = 0;

            for (int x = 0; x < 10000; x++)
            {
                for (int i = _startingCoins; i >= 0; i -= _betAmount)
                {
                    if (rand.Next(1, 100) <= _winProbability)
                        _battlePoints += 2 * _betAmount;
                }

                if (averagePoints == 0)
                {
                    averagePoints = _battlePoints;
                    minPoints = _battlePoints;
                    maxPoints = _battlePoints;

                    using (StreamWriter stream = new StreamWriter(String.Format(@"C:\Temp\probability{0}.csv", _betAmount)))
                    {
                        stream.WriteLine("Battle Points");
                    }
                }
                else
                {
                    averagePoints = (averagePoints + _battlePoints) / 2;

                    if (_battlePoints < minPoints)
                        minPoints = _battlePoints;
                    if (_battlePoints > maxPoints)
                        maxPoints = _battlePoints;
                }

                using (StreamWriter stream = new StreamWriter(String.Format(@"C:\Temp\probability{0}.csv", _betAmount), true))
                {
                    stream.WriteLine(_battlePoints);
                }

                _battlePoints = 0;
            }

            Console.WriteLine("Avg battle Points: {0}", averagePoints);
            Console.WriteLine("Min Battle Points: {0}", minPoints);
            Console.WriteLine("Max Battle Points: {0}", maxPoints);
            Console.ReadLine();
        }
    }
}
