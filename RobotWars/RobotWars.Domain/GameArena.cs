using System.Drawing;

namespace RobotWars.Domain
{
	public class GameArena
	{
		private readonly Point bottomLeftPosition = new Point(0,0);
		private readonly Point topRightPosition;

		public GameArena(int width, int height)
		{
			topRightPosition = new Point(width, height);	
		}

		public Point GetArenaBottomLeft()
		{
			return bottomLeftPosition;
		}

		public Point GetArenaTopRight()
		{
			return topRightPosition;
		}
	}
}
