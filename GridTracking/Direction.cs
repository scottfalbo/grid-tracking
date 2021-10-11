using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking
{
    public class Direction
    {
        /// <summary>
        /// Get a random direction for the movement.
        /// </summary>
        /// <returns> random Direction enum </returns>
        public static int[] GetRandomDirection()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var randomValue = random.Next(0, 4);
            return DirectionToCoords((RandomDirection)randomValue);
        }

        /// <summary>
        /// Converts the Direction enum result into x, y movement adjustment.
        /// Up = {-1, 0}, Down = {1, 0}, Left = {0, -1}, Right = {0, 1}
        /// </summary>
        /// <param name="direction"> Direction direction </param>
        /// <returns> int[]{x, y} </returns>
        public static int[] DirectionToCoords(RandomDirection direction)
        {
            int[] move = new int[2] { 0, 0 };
            switch (direction)
            {
                case RandomDirection.Up:
                    move[0] -= 1;
                    break;
                case RandomDirection.Down:
                    move[0] += 1;
                    break;
                case RandomDirection.Left:
                    move[1] -= 1;
                    break;
                case RandomDirection.Right:
                    move[0] += 1;
                    break;
                default:
                    break;
            }
            return move;
        }
    }

    public enum RandomDirection
    {
        Up,
        Down,
        Left,
        Right
    }

}
