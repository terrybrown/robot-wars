using System.Drawing;

namespace RobotWars.Domain
{
	public class GameArena
	{
		private readonly Point _bottomLeftPosition = new Point(0,0);
		private readonly Point _topRightPosition;

		public GameArena(int width, int height)
		{
			_topRightPosition = new Point(width, height);	
		}

		public Point GetArenaBottomLeft()
		{
			return _bottomLeftPosition;
		}

		public Point GetArenaTopRight()
		{
			return _topRightPosition;
		}
	}
}
