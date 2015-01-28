using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace RobotWars.Domain.Robot
{
	internal class RobotPosition
	{
		private Point currentPosition;

		public RobotPosition(Point positionOnArena)
		{
			if (positionOnArena == null)
			{
				throw new ArgumentOutOfRangeException("positionOnArena", "Invalid position specificed for the robot");				
			}

			currentPosition = positionOnArena;
		}

		public int X { get { return currentPosition.X; } }
		public int Y { get { return currentPosition.Y; } }

		public Point GetCurrentLocation()
		{
			return currentPosition;
		}

		public void SetCurrentLocation(Point newLocation)
		{
			currentPosition = newLocation;
		}

		public static bool TryParsePosition(string userInput, out Point position)
		{
			if (string.IsNullOrWhiteSpace(userInput) || !userInput.Contains(","))
			{
				position = new Point(0, 0);
				return false;
			}

			string[] xAndY = Regex.Replace(userInput, @"\s+", "").Split(',');

			int x, y;
			if (int.TryParse(xAndY[0], out x) && int.TryParse(xAndY[1], out y))
			{
				position = new Point(x, y);
				return true;
			}

			position = new Point(0, 0);
			return false;
		}

		public Point GetLocationAfterMove(string orientation)
		{
			Point newLocation = currentPosition;
			switch (orientation)
			{
				case "N":
					newLocation.Y += 1;
					break;
				case "E":
					newLocation.X += 1;
					break;
				case "S":
					newLocation.Y -= 1;
					break;
				case "W":
					newLocation.X -= 1;
					break;
				default:
					throw new ArgumentOutOfRangeException("orientation");
			}

			return newLocation;
		}
	}
}