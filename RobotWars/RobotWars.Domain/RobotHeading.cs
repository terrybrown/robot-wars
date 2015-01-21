using System;

namespace RobotWars.Domain
{
	public class RobotHeading
	{
		private char _currentHeading;
		private readonly char[] _validHeadings = { 'N', 'E', 'S', 'W' };

		public RobotHeading(char heading = 'N')
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

		public char GetHeading()
		{
			return _currentHeading;
		}

	}
}