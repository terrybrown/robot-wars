using System;
using System.Drawing;
using RobotWars.Domain.Contracts;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain.Robot
{
	public class Robot : IRobot
	{
		private readonly IOutputRenderer renderer;
		private readonly RobotOrientation orientation;
		private readonly RobotMoves robotMoves;
		private readonly RobotPosition robotPosition;

		private Point? arenaBottomLeft;
		private Point? arenaTopRight;

		public Robot(IOutputRenderer renderer, Point positionOnArena, Orientation orientation, string preProgrammedMoves)
		{
			this.renderer		= renderer;
			robotPosition		= new RobotPosition(positionOnArena);
			this.orientation	= new RobotOrientation(renderer, orientation);
			robotMoves			= new RobotMoves(preProgrammedMoves);
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot is outside of the arena</exception>
		public void SetArenaSize(Point bottomLeft, Point topRight)
		{
			arenaBottomLeft = bottomLeft;
			arenaTopRight = topRight;

			VerifyLocationIsWithinArena(robotPosition.GetCurrentLocation());
		}

		/// <exception cref="ArgumentNullException">Thrown when the arena hasn't been setup</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot attempts to move outside of the arena</exception>
		public void PerformNextMove()
		{
			if (arenaBottomLeft == null || arenaTopRight == null) 
				throw new ArgumentNullException("Arena not setup");

			char? nextMove = robotMoves.GetNextMove();
			if (nextMove != null)
			{
				switch (nextMove)
				{
					case 'L':
						orientation.TurnLeft();
						break;
					case 'R':
						orientation.TurnRight();
						break;
					case 'M':
						MoveForward();
						break;
				}
			}
		}

		public bool HasMovesRemaining()
		{
			return robotMoves.HasMovedRemaining();
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot attempts to move outside of the arena</exception>
		private void MoveForward()
		{
			string currentOrientation	= orientation.GetOrientationAsSingleLetterCompassPoint();
			Point newLocation			= robotPosition.GetLocationAfterMove(currentOrientation);

			VerifyLocationIsWithinArena(newLocation);

			robotPosition.SetCurrentLocation(newLocation);

			renderer.RenderDebug("Moving forward to: " + ToString());
		}

		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private void VerifyLocationIsWithinArena(Point newLocation)
		{
			if (newLocation.X < arenaBottomLeft.Value.X || newLocation.X > arenaTopRight.Value.X ||
				newLocation.Y < arenaBottomLeft.Value.Y || newLocation.Y > arenaTopRight.Value.Y)
			{
				throw new ArgumentOutOfRangeException("newLocation", "The new location would take this robot outside of the arena");
			}

		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", robotPosition.X, robotPosition.Y, orientation.GetOrientationAsSingleLetterCompassPoint());
		}
	}
}