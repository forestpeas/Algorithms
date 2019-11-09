using System;

namespace Algorithms.LeetCode
{
    /* 223. Rectangle Area
     * 
     * Find the total area covered by two rectilinear rectangles in a 2D plane.
     * Each rectangle is defined by its bottom left corner and top right corner as shown in the figure.
     * 
     * https://leetcode.com/problems/rectangle-area/
     */
    public class RectangleArea
    {
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            // Compute the overlapping area.
            int width = 0;
            if (A <= E && C > E)
            {
                width = Math.Min(C, G) - E;
            }
            else if (A < G && C >= G)
            {
                width = G - Math.Max(A, E);
            }
            else if (A > E && C < G)
            {
                width = C - A;
            }

            int height = 0;
            if (D >= H && B < H)
            {
                height = H - Math.Max(B, F);
            }
            else if (D > F && B <= F)
            {
                height = Math.Min(D, H) - F;
            }
            else if (D < H && B > F)
            {
                height = D - B;
            }

            return (C - A) * (D - B) + (G - E) * (H - F) - width * height;
        }

        public int ComputeArea2(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            // Inspired by the discuss section.
            int left = Math.Max(A, E);
            int right = Math.Min(G, C);
            int bottom = Math.Max(F, B);
            int top = Math.Min(D, H);

            int overlap = 0;
            if (right > left && top > bottom) overlap = (right - left) * (top - bottom);

            return (C - A) * (D - B) + (G - E) * (H - F) - overlap;
        }
    }
}
