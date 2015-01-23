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

		private Point? _arenaBottomLeft;
		private Point? _arenaTopRight;

		public Robot(IOutputRenderer renderer, Point positionOnArena, Orientation orientation, string preProgrammedMoves)
		{
			_renderer		= renderer;
			_robotPosition	= new RobotPosition(positionOnArena);
			_orientation	= new RobotOrientation(orientation);
			_robotMoves		= new RobotMoves(preProgrammedMoves);
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot is outside of the arena</exception>
		internal void SetArenaSize(Point arenaBottomLeft, Point arenaTopRight)
		{
			_arenaBottomLeft = arenaBottomLeft;
			_arenaTopRight = arenaTopRight;

			VerifyLocationIsWithinArena(_robotPosition.GetCurrentLocation());
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
						try
						{
							MoveForward();
						}
						catch (ArgumentOutOfRangeException)
						{
							_renderer.RenderError("Attempt to move to a location outside of the arena - FROM: {0} DIRECTION: {1}", 
													_robotPosition.GetCurrentLocation(), 
													_orientation.ToString());
						}
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

		/// <exception cref="ArgumentNullException">Thrown when the arena hasn't been setup</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot attempts to move outside of the arena</exception>
		public void MoveForward()
		{
			if (_arenaBottomLeft == null || _arenaTopRight == null) 
				throw new ArgumentNullException("Arena not setup");

			string _currentOrientation	= _orientation.GetOrientationAsSingleLetterCompassPoint();
			Point _newLocation			= GetNewLocation(_robotPosition.GetCurrentLocation(), _currentOrientation);

			VerifyLocationIsWithinArena(_newLocation);

			_robotPosition.SetCurrentLocation(_newLocation);

			_renderer.RenderDebug("Moving forward to: " + ToString());
		}

		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private void VerifyLocationIsWithinArena(Point newLocation)
		{
			if (newLocation.X < _arenaBottomLeft.Value.X || newLocation.X > _arenaTopRight.Value.X ||
				newLocation.Y < _arenaBottomLeft.Value.Y || newLocation.Y > _arenaTopRight.Value.Y)
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
			return string.Format("{0} {1} {2}", _robotPosition.X, _robotPosition.Y, _orientation.GetOrientationAsSingleLetterCompassPoint());
		}
	}
}