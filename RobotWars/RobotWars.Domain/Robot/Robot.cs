using System;
using System.Drawing;
using RobotWars.Domain.Contracts;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain.Robot
{
	public class Robot : IRobot
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
			_orientation	= new RobotOrientation(renderer, orientation);
			_robotMoves		= new RobotMoves(preProgrammedMoves);
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot is outside of the arena</exception>
		public void SetArenaSize(Point arenaBottomLeft, Point arenaTopRight)
		{
			_arenaBottomLeft = arenaBottomLeft;
			_arenaTopRight = arenaTopRight;

			VerifyLocationIsWithinArena(_robotPosition.GetCurrentLocation());
		}

		/// <exception cref="ArgumentNullException">Thrown when the arena hasn't been setup</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot attempts to move outside of the arena</exception>
		public void PerformProgrammedMoves()
		{
			char? _nextMove = _robotMoves.GetNextMove();
			while (_nextMove != null)
			{
				switch (_nextMove)
				{
					case 'L':
						_orientation.TurnLeft();
						break;
					case 'R':
						_orientation.TurnRight();
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

		/// <exception cref="ArgumentNullException">Thrown when the arena hasn't been setup</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot attempts to move outside of the arena</exception>
		private void MoveForward()
		{
			if (_arenaBottomLeft == null || _arenaTopRight == null) 
				throw new ArgumentNullException("Arena not setup");

			string _currentOrientation	= _orientation.GetOrientationAsSingleLetterCompassPoint();
			Point _newLocation			= _robotPosition.GetLocationAfterMove(_currentOrientation);

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

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", _robotPosition.X, _robotPosition.Y, _orientation.GetOrientationAsSingleLetterCompassPoint());
		}
	}
}