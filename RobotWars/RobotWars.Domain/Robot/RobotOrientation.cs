using System;
using System.Linq;

namespace RobotWars.Domain.Robot
{
	public class RobotOrientation
	{
		private Orientation _currentOrientation;
		private static readonly Orientation[] ValidOrientations = { Orientation.North, 
																	Orientation.East, 
																	Orientation.South,
																	Orientation.West };

		public RobotOrientation(Orientation orientation = Orientation.North)
		{
			_currentOrientation = orientation;
		}

		public RobotOrientation TurnLeft()
		{
			int _nextIndex = Array.IndexOf(ValidOrientations, _currentOrientation) - 1;
			if (_nextIndex < 0)
			{
				_nextIndex = ValidOrientations.Length -1;
			}

			_currentOrientation = ValidOrientations[_nextIndex];
			
			return this;
		}

		public RobotOrientation TurnRight()
		{
			int _nextIndex = Array.IndexOf(ValidOrientations, _currentOrientation) + 1;
			if (_nextIndex > ValidOrientations.Length -1)
			{
				_nextIndex = 0;
			}

			_currentOrientation = ValidOrientations[_nextIndex];

			return this;
		}

		public string GetOrientationAsSingleLetterCompassPoint()
		{
			return _currentOrientation.ToString().Substring(0, 1);	// better way than this, quick fix for now
		}

		public static bool TryParseOrientation(string inputOrientation, out Orientation orientation)
		{
			if (string.IsNullOrWhiteSpace(inputOrientation))
			{
				orientation = Orientation.North;
				return false;
			}

			Orientation _parsedOrientation;
			switch (inputOrientation.Substring(0, 1).ToUpperInvariant())
			{
				case "N":
					_parsedOrientation = Orientation.North;
					break;
				case "E":
					_parsedOrientation = Orientation.East;
					break;
				case "S":
					_parsedOrientation = Orientation.South;
					break;
				case "W":
					_parsedOrientation = Orientation.West;
					break;
				default:
					orientation = Orientation.North;
					return false;
					
			}
			orientation = _parsedOrientation;

			return ValidOrientations.Any( x => x == _parsedOrientation);
		}

		public override string ToString()
		{
			return _currentOrientation.ToString();
		}
	}
}