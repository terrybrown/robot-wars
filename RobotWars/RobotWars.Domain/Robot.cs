using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RobotWars.Domain
{
	public class Robot
	{
		private Point _currentLocation;
		private readonly RobotOrientation _orientation;
		private Queue<char> _preProgrammedMoves;
		private Point _arenaSize;

		public Robot(int x, int y, Orientation orientation, string moves, Point arenaSize)
		{
			_currentLocation = new Point(x, y);
			_preProgrammedMoves = new Queue<char>(moves.ToList());
			_orientation = new RobotOrientation(orientation);
			_arenaSize = arenaSize;
		}

		public void PerformProgrammedMoves()
		{
			while (_preProgrammedMoves.Count > 0)
			{
				switch (_preProgrammedMoves.Dequeue())
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
			}
		}

		public void TurnRobotLeft()
		{
			Console.WriteLine("Turning left");
			_orientation.TurnLeft();
		}

		public void TurnRobotRight()
		{
			Console.WriteLine("Turning right");
			_orientation.TurnRight();
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot attempts to move outside of the arena</exception>
		public void MoveForward()
		{
			string _currentOrientation	= _orientation.GetOrientation();
			Point _newLocation		= GetNewLocation(_currentLocation, _currentOrientation);

			VerifyNewLocationIsWithinArena(_newLocation);

			_currentLocation = _newLocation;

			Console.WriteLine("Moving forward to: " + this.ToString());
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
			return string.Format("{0} {1} {2}", _currentLocation.X, _currentLocation.Y, _orientation.GetOrientation());
		}
	}
}