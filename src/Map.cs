using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace dis2voxel
{
    class Map
    {
        private Bitmap bitmap;
        public int[,] Bitmap2DArray;
        public Map(Image image)
        {
            bitmap = new Bitmap(image);
            Bitmap2DArray = Map.BitmapTo2DArray(bitmap, "red");
        }

        public static int[,] BitmapTo2DArray(Bitmap bitmap, string color)
        {
            int [,] bitmapMatrix = new int[bitmap.Width, bitmap.Height];

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    switch (color)
                    {
                        case "red":
                            bitmapMatrix[x, y] = bitmap.GetPixel(x, y).R;
                            break;
                        case "blue":
                            bitmapMatrix[x, y] = bitmap.GetPixel(x, y).B;
                            break;
                        case "green":
                            bitmapMatrix[x, y] = bitmap.GetPixel(x, y).G;
                            break;
                        case "alpha":
                            bitmapMatrix[x, y] = bitmap.GetPixel(x, y).A;
                            break;
                    }
                }
            }

            return bitmapMatrix;
        }

        public static int Average2DArrayValues(int[,] array)
        {
            int averagedValue = 0;
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(0); y++)
                {
                    averagedValue += array[x, y];
                }

            }
            averagedValue = averagedValue / array.Length;

            return averagedValue;
        }

        public static string Int2DArrayToString(int[,] array)
        {
            string matrixString = "";

            int matrixXLength = array.GetLength(0);
            int matrixYLength = array.GetLength(1);

            for (int y = 0; y < matrixYLength; y++)
            {
                for (int x = 0; x < matrixXLength; x++)
                {
                    if (x != 0)
                    {
                        matrixString += " " + array[x, y];
                    }
                    else
                    {
                        matrixString += "\n" + array[x, y];
                    }
                }

            }
            return matrixString;
        }

        public static int[,] TrimFat(int[,] array, int sections)
        {
            // check if trimming needs to be done
            if (array.GetLength(0) % sections == 0) { return array; };

            int[] arrayLength = { array.GetLength(0), array.GetLength(1)};
            int[] arrayFatLength = { arrayLength[0] % sections, arrayLength[1] % sections };
            int[] arrayCutLength = { arrayLength[0] - arrayFatLength[0], arrayLength[1] - arrayFatLength[1] };

            int[,] cutArray = new int[arrayCutLength[0],arrayCutLength[1]];

            for (int y = 0; y < arrayLength[1] - arrayFatLength[1]; y++)
            {
                for (int x = 0; x < arrayLength[0] - arrayFatLength[0]; x++)
                {
                    cutArray[x, y] = array[x, y];
                }
            }
            return cutArray;
        }

        public static int[,] GetSection(int[,] array, int startX, int startY, int sectionLength)
        {
            int[,] newArray = new int[sectionLength,sectionLength];

            for (int y = startY; y < (startY + sectionLength); y++)
            {
                for (int x = startX; x < (startX + sectionLength); x++)
                {
                    newArray[x - startX, y - startY] = array[x , y];
                }

            }
            return newArray;
        }
    }
}
