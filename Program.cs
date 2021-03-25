using System;
using System.Drawing;

namespace dis2voxel
{
    class Program
    {
        static void Main(string[] args)
        {
            Image image = Image.FromFile(args[0]);
            Map map = new(image);

            string matrixString = "";

            int matrixXLength = map.bitmapMatrix.GetLength(0);
            int matrixYLength = map.bitmapMatrix.GetLength(1);

            for (int y = 0; y < matrixXLength; y++)
            {
                for (int x = 0; x < matrixXLength; x++)
                {
                    if (x != 0)
                    {
                        matrixString += " " + map.bitmapMatrix[x, y];
                    } else
                    {
                        matrixString += "\n" + map.bitmapMatrix[x, y];
                    }
                }

            }

            Console.WriteLine(matrixString);
        }
    }


}
