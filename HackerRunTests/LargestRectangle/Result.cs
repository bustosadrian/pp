using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRunTests.LargestRectangle
{
    internal class Result
    {
        public static long largestRectangle(List<int> h)
        {
            long maxSurface = 0;

            Dictionary<long, Rectangle> rectangles = new Dictionary<long, Rectangle>();
            var ar = h.ToArray();
            int previousHeight = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                var height = ar[i];
                
                if(height > previousHeight)
                {
                    Rectangle rectangle = new Rectangle()
                    {
                        StartingPosition = i,
                        Height = height,
                    };
                    if (rectangles.ContainsKey(height))
                    {
                        "".ToString();
                    }
                    rectangles.Add(height, rectangle);
                }
                else if (height < previousHeight)
                {
                    if (!rectangles.ContainsKey(height))
                    {
                        Rectangle rectangle = new Rectangle()
                        {
                            StartingPosition = GetClosestRectangleStartingPosition(rectangles, height),
                            Height = height,
                        };
                        rectangles.Add(height, rectangle);
                    }

                    var rectanglesToClose = rectangles.Where(x => x.Key > height).ToList();
                    maxSurface = CloseRectanglesAndCalculateMaxSurface(maxSurface, rectangles, rectanglesToClose, i);
                }
                previousHeight = height;
            }
            maxSurface = CloseRectanglesAndCalculateMaxSurface(maxSurface, null, rectangles, ar.Length);

            return maxSurface;
        }

        private static long CloseRectanglesAndCalculateMaxSurface(long currentSurface,
            Dictionary<long, Rectangle> rectangles, IEnumerable<KeyValuePair<long, Rectangle>> rectanglesToClose, long index)
        {
            long retval = currentSurface;
            foreach (var o in rectanglesToClose)
            {
                var rectangle = o.Value;

                //Calculate surface and save if bigger
                long surface = (index - rectangle.StartingPosition) * rectangle.Height;
                retval = surface > retval ? surface : retval;

                //Remove rectangle from open rectangles
                if(rectangles != null)
                {
                    rectangles.Remove(o.Key);
                }
            }
            return retval;
        }

        private static int GetClosestRectangleStartingPosition(Dictionary<long, Rectangle> rectangles, int height)
        {
            return rectangles.Values.Where(x => x.Height > height).Min(x => x.StartingPosition);
        }

        class Rectangle
        {
            public int StartingPosition
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }
        }
    }
}
