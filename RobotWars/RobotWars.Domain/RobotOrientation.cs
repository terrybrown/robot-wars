using System;

namespace RobotWars.Domain
{
	public class RobotOrientation
	{
		private Orientation _currentOrientation;
		private readonly Orientation[] _validOrientations = { Orientation.North, 
																Orientation.East, 
																Orientation.South,
																Orientation.West };

		public RobotOrientation(Orientation orientation = Orientation.North)
		{
			_currentOrientation = orientation;
		}

		public RobotOrientation TurnLeft()
		{
			int _nextIndex = Array.IndexOf(_validOrientations, _currentOrientation) - 1;
			if (_nextIndex < 0)
			{
				_nextIndex = _validOrientations.Length -1;
			}

			_currentOrientation = _validOrientations[_nextIndex];
			
			return this;
		}

		public RobotOrientation TurnRight()
		{
			int _nextIndex = Array.IndexOf(_validOrientations, _currentOrientation) + 1;
			if (_nextIndex > _validOrientations.Length -1)
			{
				_nextIndex = 0;
			}

			_currentOrientation = _validOrientations[_nextIndex];

			return this;
		}

		public string GetOrientation()
		{
			return _currentOrientation.ToString().Substring(0, 1);	// better way than this, quick fix for now
		}

	}
}