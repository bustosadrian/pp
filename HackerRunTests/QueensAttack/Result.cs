using System;
using System.Collections.Generic;

namespace HackerRunTests.QueensAttack
{
    public class Result
    {
        private const int ROW = 0;
        private const int COLUMN = 1;

        /*
         * Complete the 'queensAttack' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER k
         *  3. INTEGER r_q
         *  4. INTEGER c_q
         *  5. 2D_INTEGER_ARRAY obstacles
         */

        public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            return QueensAttackInverted(n, k, r_q, c_q, obstacles);
        }
        public static int QueensAttackInverted(int n, int k, int queenRow, int queenColumn, List<List<int>> obstacles)
        {
            int squares = 0;

            int marginLeft = 1;
            int marginRight = n;
            int marginTop = n;
            int marginBottom = 1;
            int[] marginTopLeft = new int[] { n, 1 };
            int[] marginBottomLeft = new int[] { 1, 1 };
            int[] marginTopRight = new int[] { n, n };
            int[] marginBottomRight = new int[] { 1, n };

            TrimMargins(queenRow, queenColumn, 
                ref marginLeft, ref marginRight, ref marginTop, ref marginBottom,
                marginTopLeft, marginTopRight, marginBottomLeft, marginBottomRight,
                obstacles);

            squares += queenColumn - marginLeft;
            squares += marginRight - queenColumn;
            squares += marginTop - queenRow;
            squares += queenRow - marginBottom;

            //Top-Left
            squares += CalculateDistance(queenRow, queenColumn, marginTopLeft[ROW], marginTopLeft[COLUMN]);
            //Bottom-Left
            squares += CalculateDistance(queenRow, queenColumn, marginBottomLeft[ROW], marginBottomLeft[COLUMN]);
            //Top-Right
            squares += CalculateDistance(queenRow, queenColumn, marginTopRight[ROW], marginTopRight[COLUMN]);
            //Bottom-Right
            squares += CalculateDistance(queenRow, queenColumn, marginBottomRight[ROW], marginBottomRight[COLUMN]);

            return squares;
        }

        private static void TrimMargins(int queenRow, int queenColumn, 
            ref int marginLeft, ref int marginRight, ref int marginTop, ref int marginBottom,
            int[] marginTopLeft, int[] marginTopRight, int[] marginBottomLeft, int[] marginBottomRight,
            List<List<int>> obstacles)
        {
            int obstacle = 0;
            foreach (var o in obstacles)
            {
                obstacle++;
                int obstacleRow = o[0];
                int obstacleColumn = o[1];

                int dRow = queenRow - obstacleRow;
                int dColumn = queenColumn - obstacleColumn;

                if(dRow != 0 && dColumn != 0 && Math.Abs(dRow) != Math.Abs(dColumn))
                {
                    continue;
                }

                if(dRow == 0)
                {
                    if (dColumn > 0)
                    {
                        marginLeft = obstacleColumn > marginLeft ? obstacleColumn + 1 : marginLeft;
                    }
                    else if (dColumn < 0)
                    {
                        marginRight = obstacleColumn < marginRight ? obstacleColumn - 1 : marginRight;
                    }
                }
                else  if(dColumn == 0)
                {
                    if (dRow < 0)
                    {
                        marginTop = obstacleRow < marginTop ? obstacleRow - 1 : marginTop;
                    }
                    else if (dRow > 0)
                    {
                        marginBottom = obstacleRow > marginBottom ? obstacleRow + 1 : marginBottom;
                    }
                }
                else
                {
                    if(dRow < 0 && dColumn > 0)
                    {
                        if(obstacleRow < marginTopLeft[ROW] && obstacleColumn > marginTopLeft[COLUMN])
                        {
                            marginTopLeft[ROW] = obstacleRow - 1;
                            marginTopLeft[COLUMN] = obstacleColumn + 1;
                        }
                        //marginTopLeft[ROW] = obstacleRow < marginTopLeft[ROW] ? obstacleRow : marginTopLeft[ROW];
                        //marginTopLeft[COLUMN] = obstacleColumn > marginTopLeft[COLUMN] ? obstacleColumn : marginTopLeft[COLUMN];
                    }
                    else if (dRow > 0 && dColumn > 0)
                    {
                        if(obstacleRow > marginBottomLeft[ROW] && obstacleColumn > marginBottomLeft[COLUMN])
                        {
                            marginBottomLeft[ROW] = obstacleRow + 1;
                            marginBottomLeft[COLUMN] = obstacleColumn + 1;
                        }
                        //marginBottomLeft[ROW] = obstacleRow > marginBottomLeft[ROW] ? obstacleRow : marginBottomLeft[ROW];
                        //marginBottomLeft[COLUMN] = obstacleColumn > marginBottomLeft[COLUMN] ? obstacleColumn : marginBottomLeft[COLUMN];
                    }
                    else if (dRow < 0 && dColumn < 0)
                    {
                        if (obstacleRow < marginTopRight[ROW] && obstacleColumn < marginTopRight[COLUMN])
                        {
                            marginTopRight[ROW] = obstacleRow - 1;
                            marginTopRight[COLUMN] = obstacleColumn - 1;
                        }
                        
                        //marginTopRight[ROW] = obstacleRow < marginTopRight[ROW] ? obstacleRow : marginTopRight[ROW];
                        //marginTopRight[COLUMN] = obstacleColumn < marginTopRight[COLUMN] ? obstacleColumn : marginTopRight[COLUMN];
                    }
                    else if (dRow > 0 && dColumn < 0)
                    {
                        if (obstacleRow > marginBottomRight[ROW] && obstacleColumn < marginBottomRight[COLUMN])
                        {
                            marginBottomRight[ROW] = obstacleRow + 1;
                            marginBottomRight[COLUMN] = obstacleColumn - 1;
                        }
                        //marginBottomRight[ROW] = obstacleRow > marginBottomRight[ROW] ? obstacleRow : marginBottomRight[ROW];
                        //marginBottomRight[COLUMN] = obstacleColumn < marginBottomRight[COLUMN] ? obstacleColumn : marginBottomRight[COLUMN];
                    }
                    else
                    {
                        throw new Exception("Unhandled case");
                    }
                }
            }
        }

        public static int CalculateDistance(int x1, int y1, int x2, int y2)
        {
            var dx = Math.Abs(x1 - x2);
            var dy = Math.Abs(y1 - y2);

            return Math.Min(dx, dy);
        }
    }

    

    public class QueensAttackResultTest
    {
        private static void Test(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            Console.WriteLine($"{n} {k}");
            Console.WriteLine($"{r_q} {c_q}");
            foreach(var o in obstacles)
            {
                Console.WriteLine($"{o[0]} {o[1]}");
            }
            Console.WriteLine($"Result: {Result.queensAttack(n, k, r_q, c_q, obstacles)}");
            Console.WriteLine();
        }

        public static void Test1()
        {
            Test(4, 0, 4, 4, new List<List<int>>());
        }

        public static void Test2()
        {
            Test(5, 3, 4, 3, new List<List<int>>
            {
                new List<int>{5, 5},
                new List<int>{4, 2},
                new List<int>{2, 3},
            });
        }

        public static void Test3()
        {
            Test(5, 1, 1, 5, new List<List<int>>
            {
                new List<int>{5, 5},
                new List<int>{4, 2},
                new List<int>{2, 3},
            });
        }

        public static void Test20()
        {
            Test(88587, 9, 20001, 20003, new List<List<int>>
            {
                new List<int>{ 20001, 20002 },
                new List<int>{ 20001, 20004 },
                new List<int>{ 20000, 20003 },
                new List<int>{ 20002, 20003 },
                new List<int>{ 20000, 20004 },
                new List<int>{ 20000, 20002 },
                new List<int>{ 20002, 20004 },
                new List<int>{ 20002, 20002 },
                new List<int>{ 564, 323 },
            });
        }
    }
}
