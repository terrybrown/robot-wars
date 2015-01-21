using System;

namespace RobotWars.Domain
{
	public class RobotHeading
	{
		private Orientation _currentHeading;
		private readonly Orientation[] _validHeadings = { Orientation.North, 
															Orientation.East, 
															Orientation.South,
															Orientation.West };

		public RobotHeading(Orientation heading = Orientation.North)
		{
			_currentHeading = heading;
		}

		public RobotHeading TurnLeft()
		{
			int _nextIndex = Array.IndexOf(_validHeadings, _currentHeading) - 1;
			if (_nextIndex < 0)
			{
				_nextIndex = _validHeadings.Length -1;
			}

			_currentHeading = _validHeadings[_nextIndex];
			
			return this;
		}

		public RobotHeading TurnRight()
		{
			int _nextIndex = Array.IndexOf(_validHeadings, _currentHeading) + 1;
			if (_nextIndex > _validHeadings.Length -1)
			{
				_nextIndex = 0;
			}

			_currentHeading = _validHeadings[_nextIndex];

			return this;
		}

		public string GetHeading()
		{
			return _currentHeading.ToString().Substring(0, 1);	// better way than this, quick fix for now
		}

	}
}