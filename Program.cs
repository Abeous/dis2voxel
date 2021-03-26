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
            int averagedSections = Int16.Parse(args[1]);

            int[,] cutArray = Map.TrimFat(map.Bitmap2DArray, averagedSections);
            Console.WriteLine(Map.Int2DArrayToString(cutArray));

            int[,] newArray = new int[averagedSections,averagedSections];
            if (averagedSections > (cutArray.GetLength(0) / 2))
            {
                newArray = cutArray;
            } else
            {
                int sectionLength = (cutArray.GetLength(0) / averagedSections);
                for (int posY = 0; posY < averagedSections; posY++)
                {
                    for (int posX = 0; posX < averagedSections; posX++)
                    {
                        int startX = posX * sectionLength;
                        int startY = posY * sectionLength;
                        int[,] newSection = Map.GetSection(cutArray, startX, startY, sectionLength);
                        newArray[posX, posY] = Map.Average2DArrayValues(newSection);
                    }

                }
            }
            Console.WriteLine(Map.Int2DArrayToString(newArray));
        }
    }


}
