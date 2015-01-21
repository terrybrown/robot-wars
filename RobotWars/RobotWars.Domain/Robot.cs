using System.Drawing;

namespace RobotWars.Domain
{
	public class Robot
	{
		private int xLocation = 0;
		private int yLocation = 0;
		private RobotHeading heading;
		private char[] preProgrammedMoves;
		private Point arenaSize;

		public Robot(int x, int y, char heading, string moves, Point arenaSize)
		{
			xLocation = x;
			yLocation = y;
			preProgrammedMoves = moves.ToCharArray();
			this.heading = new RobotHeading(heading);
			this.arenaSize = arenaSize;
		}


		public void TurnRobotLeft()
		{
			
		}

		public void TurnRobotRight()
		{
			
		}

	}
}