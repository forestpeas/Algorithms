using System;

namespace Algorithms.LeetCode
{
    /* 478. Generate Random Point in a Circle
     * 
     * Given the radius and x-y positions of the center of a circle, write a function
     * randPoint which generates a uniform random point in the circle.
     */
    public class Generate_Random_Point_in_a_Circle
    {
        public class Solution
        {
            private readonly double radius;
            private readonly double x_center;
            private readonly double y_center;
            private readonly Random rdm = new Random();

            public Solution(double radius, double x_center, double y_center)
            {
                this.radius = radius;
                this.x_center = x_center;
                this.y_center = y_center;
            }

            public double[] RandPoint()
            {
                // Rejection Sampling. Generate a point from a square and check whether
                // it is within the circle.
                double x, y;
                do
                {
                    // "rdm.NextDouble() * 2 - 1" ranges from -1 to 1.
                    x = (rdm.NextDouble() * 2 - 1) * radius;
                    y = (rdm.NextDouble() * 2 - 1) * radius;
                } while (x * x + y * y > radius * radius);

                return new double[] { x + x_center, y + y_center };
            }

            public double[] RandPoint2()
            {
                // Polar Coordinates.
                // x is a random number from 0 to 1, R is the radius.
                // π*r^2 = x*π*R^2
                // r = sqrt(x)*R
                double r = Math.Sqrt(rdm.NextDouble()) * radius;
                double d = rdm.NextDouble() * 2 * Math.PI;
                double x = r * Math.Cos(d) + x_center;
                double y = r * Math.Sin(d) + y_center;
                return new double[] { x, y };
            }
        }
    }
}
