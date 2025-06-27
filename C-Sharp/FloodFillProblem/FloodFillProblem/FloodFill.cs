using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFillProblem
{
    public class FloodFill
    {
        public bool IsValid(int[,] img, int row, int col) =>
            row >= 0 && row < img.GetLength(0) &&
            col >= 0 && col < img.GetLength(1);

        private List<(int, int)> Neighbors(int[,] img, int row, int col, int start)
        {
            (int row, int col)[] indices = {(row -1, col), (row + 1, col),
                             (row, col - 1), (row, col + 1)};

            List<(int, int)> validIndices = new List<(int, int)>();
            foreach (var index in indices)
                if (IsValid(img, index.row, index.col) && img[index.row, index.col] == start)
                    validIndices.Add(index);

            return validIndices;
        }

        public void Fill(int[,] img, (int row, int col) startingIndex, int newColor)
        {
            if (!IsValid(img, startingIndex.row, startingIndex.col))
                throw new ArgumentException("Starting position is not valid");
            
            int startColor = img[startingIndex.row, startingIndex.col];
            if (startColor == newColor) return;
            
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue(startingIndex);
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                if (!visited.Add((row, col))) continue; // Skip if already visited
                img[row, col] = newColor;
                
                foreach (var neighbor in Neighbors(img, row, col, startColor))
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }
        }
    }
}
