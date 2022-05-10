using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Multiverse
{
    class MarsRoverController
    {
        static int row = 0, col = 0;
        static void Main(string[] args)
        {
            List<GridPositionWithOrientation> list = ReadInput();
            MarsRoverService service = new MarsRoverService(row, col);
            GiveCommandsToBots(list, service);
            PrintLastKnownPositions(list);
        }

        private static void PrintLastKnownPositions(List<GridPositionWithOrientation> list) {
            Console.WriteLine("Last known positions of bots:");
            Parallel.ForEach(list, i =>
            {
                Console.WriteLine(i.xCoordinate + " " + i.yCoordinate + " " + i.orientation+""+(i.isLost ? " LOST" : ""));
            });
        }

        private static void GiveCommandsToBots(List<GridPositionWithOrientation> list, MarsRoverService service)
        {
            try {
                Parallel.ForEach(list, i =>
                {
                    foreach (char cmd in i.commands)
                    {
                        if (cmd == 'F')
                        {
                            service.MoveForward(i);
                        }
                        else if (cmd == 'L')
                        {
                            service.Rotate(i, "L");
                        }
                        else if (cmd == 'R')
                        {
                            service.Rotate(i, "R");
                        } else
                        throw new InvalidOperationException();
                    }
                });
            }
            catch(InvalidOperationException) {
                Console.Error.WriteLine("Invalid command give to robot");
            }

        }

        public static List<GridPositionWithOrientation> ReadInput() {
            List<GridPositionWithOrientation> inputList = new List<GridPositionWithOrientation>();

            try {
                Console.WriteLine("Enter input:");
                string grid = Console.ReadLine().Trim();
                int numberOfBots = Int32.Parse(Console.ReadLine());

                string[] gridSize = grid.Split(" ").ToArray();
                row = Int32.Parse(gridSize[0]);
                col = Int32.Parse(gridSize[1]);

                while (numberOfBots > 0) {
                string[] botPosition = Console.ReadLine().Split(" ");
                inputList.Add(new GridPositionWithOrientation
                (Int32.Parse(botPosition[0]),
                Int32.Parse(botPosition[1]),
                botPosition[2],
                botPosition[3]));
                numberOfBots--;
                }
            }
            catch(Exception) {
                Console.Error.WriteLine("Exception in reading input.");
            }

            return inputList;
        }
    }
}
