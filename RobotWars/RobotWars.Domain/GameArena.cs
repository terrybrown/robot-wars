using System.Drawing;

namespace RobotWars.Domain
{
	public class GameArena
	{
		private int[,] grid;
		private readonly Point gridSize;

		public GameArena(int width, int height)
		{
			gridSize = new Point(width, height);

			grid = new int[gridSize.X, gridSize.Y];
		}

		public Point GetArenaSize()
		{
			return gridSize;
		}
	}
}
