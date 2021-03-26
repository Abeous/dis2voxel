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
            Console.WriteLine(cutArray.GetLength(0));

        }
    }


}
