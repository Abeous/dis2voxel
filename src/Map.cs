using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace dis2voxel
{
    class Map
    {
        private Bitmap bitmap;
        public int[,] bitmapMatrix;
        public Map(Image image)
        {
            bitmap = new Bitmap(image);
            bitmapMatrix = Map.MatrixFromBitmap(bitmap, "red");
        }

        static int[,] MatrixFromBitmap(Bitmap bitmap, string color)
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
    }
}
