using System.Drawing;

namespace RobotWars.Domain
{
	public class GameArena
	{
		private Region _grid;

		public GameArena(int width, int height)
		{
			_grid = new Region(new Rectangle(0, 0, width, height));
		}

		public Point GetArenaSize()
		{
			//return gridSize;

			return new Point(10, 10);
		}
	}
}
