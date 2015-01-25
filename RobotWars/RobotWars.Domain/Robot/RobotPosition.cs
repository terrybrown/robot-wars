using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace RobotWars.Domain.Robot
{
	internal class RobotPosition
	{
		private Point _currentPosition;

		public RobotPosition(Point positionOnArena)
		{
			if (positionOnArena == null)
			{
				throw new ArgumentOutOfRangeException("positionOnArena", "Invalid position specificed for the robot");				
			}

			_currentPosition = positionOnArena;
		}

		public int X { get { return _currentPosition.X; } }
		public int Y { get { return _currentPosition.Y; } }

		public Point GetCurrentLocation()
		{
			return _currentPosition;
		}

		public void SetCurrentLocation(Point newLocation)
		{
			_currentPosition = newLocation;
		}

		public static bool TryParsePosition(string userInput, out Point position)
		{
			if (string.IsNullOrWhiteSpace(userInput) || !userInput.Contains(","))
			{
				position = new Point(0, 0);
				return false;
			}

			string[] _xAndY = Regex.Replace(userInput, @"\s+", "").Split(',');

			int _x, _y;
			if (int.TryParse(_xAndY[0], out _x) && int.TryParse(_xAndY[1], out _y))
			{
				position = new Point(_x, _y);
				return true;
			}

			position = new Point(0, 0);
			return false;
		}

		public Point GetLocationAfterMove(string orientation)
		{
			Point _newLocation = _currentPosition;
			switch (orientation)
			{
				case "N":
					_newLocation.Y += 1;
					break;
				case "E":
					_newLocation.X += 1;
					break;
				case "S":
					_newLocation.Y -= 1;
					break;
				case "W":
					_newLocation.X -= 1;
					break;
				default:
					throw new ArgumentOutOfRangeException("orientation");
			}

			return _newLocation;
		}
	}
}