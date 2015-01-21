using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RobotWars.Domain
{
	public class Robot
	{
		private Point _currentLocation;
		private readonly RobotHeading _heading;
		private Queue<char> _preProgrammedMoves;
		private Point _arenaSize;

		public Robot(int x, int y, Orientation heading, string moves, Point arenaSize)
		{
			_currentLocation = new Point(x, y);
			_preProgrammedMoves = new Queue<char>(moves.ToList());
			_heading = new RobotHeading(heading);
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
			_heading.TurnLeft();
		}

		public void TurnRobotRight()
		{
			Console.WriteLine("Turning right");
			_heading.TurnRight();
		}

		public void MoveForward()
		{
			string _currentHeading	= _heading.GetHeading();
			Point _newLocation		= GetNewLocation(_currentLocation, _currentHeading);

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

		private Point GetNewLocation(Point currentLocation, string heading)
		{
			switch (heading)
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
					throw new ArgumentOutOfRangeException("heading");
			}

			return currentLocation;
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", _currentLocation.X, _currentLocation.Y, _heading.GetHeading());
		}
	}
}