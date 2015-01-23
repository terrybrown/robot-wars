using System;
using System.Drawing;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain.Robot
{
	public class Robot
	{
		private readonly IOutputRenderer _renderer;
		private readonly RobotOrientation _orientation;
		private readonly RobotMoves _robotMoves;
		private readonly RobotPosition _robotPosition;

		private Point _arenaSize;

		internal Robot(IOutputRenderer renderer, int x, int y, Orientation orientation, string preProgrammedMoves, Point arenaSize) 
			: this(renderer, new Point(x, y), orientation, preProgrammedMoves)
		{
			_arenaSize = arenaSize;
		}

		public Robot(IOutputRenderer renderer, Point positionOnArena, Orientation orientation, string preProgrammedMoves)
		{
			_renderer		= renderer;
			_robotPosition	= new RobotPosition(positionOnArena);
			_orientation	= new RobotOrientation(orientation);
			_robotMoves		= new RobotMoves(preProgrammedMoves);
		}

		internal void SetArenaSize(Point arenaSize)
		{
			_arenaSize = arenaSize;
		}

		public void PerformProgrammedMoves()
		{
			char? _nextMove = _robotMoves.GetNextMove();
			while (_nextMove != null)
			{
				switch (_nextMove)
				{
					case 'L':
						TurnRobotLeft();
						break;
					case 'R':
						TurnRobotRight();
						break;
					case 'M':
						MoveForward();
						break;
				}

				_nextMove = _robotMoves.GetNextMove();
			}
		}

		public void TurnRobotLeft()
		{
			_renderer.RenderDebug("Turning left");
			_orientation.TurnLeft();
		}

		public void TurnRobotRight()
		{
			_renderer.RenderDebug("Turning right");
			_orientation.TurnRight();
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot attempts to move outside of the arena</exception>
		public void MoveForward()
		{
			string _currentOrientation	= _orientation.GetOrientation();
			Point _newLocation		= GetNewLocation(_robotPosition.GetCurrentLocation(), _currentOrientation);

			VerifyNewLocationIsWithinArena(_newLocation);

			_robotPosition.SetCurrentLocation(_newLocation);

			_renderer.RenderDebug("Moving forward to: " + ToString());
		}

		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private void VerifyNewLocationIsWithinArena(Point newLocation)
		{
			if (newLocation.X < 0 || newLocation.X > _arenaSize.X ||
				newLocation.Y < 0 || newLocation.Y > _arenaSize.Y)
			{
				throw new ArgumentOutOfRangeException("newLocation", "The new location would take this robot outside of the arena");
			}

		}

		private Point GetNewLocation(Point currentLocation, string orientation)
		{
			switch (orientation)
			{
				case "N":
					currentLocation.Y += 1;
					break;
				case "E":
					currentLocation.X += 1;
					break;
				case "S":
					currentLocation.Y -= 1;
					break;
				case "W":
					currentLocation.X -= 1;
					break;
				default:
					throw new ArgumentOutOfRangeException("orientation");
			}

			return currentLocation;
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", _robotPosition.X, _robotPosition.Y, _orientation.GetOrientation());
		}
	}
}