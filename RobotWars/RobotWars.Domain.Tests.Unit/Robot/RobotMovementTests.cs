using System;
using System.Drawing;
using NUnit.Framework;

namespace RobotWars.Domain.Tests.Unit.Robot
{
	[TestFixture]
	public class RobotMovementTests
	{
		private const int ARENA_WIDTH = 10;
		private const int ARENA_HEIGHT = 10;
		private static readonly NullRenderer _renderer = new NullRenderer();

		static readonly Point ArenaBottomLeft = new Point(0, 0);
		static readonly Point ArenaTopRight = new Point(ARENA_WIDTH, ARENA_HEIGHT);

		public class WhenMovingWithinArenaBounds
		{
			[Test]
			public void OneSpaceNorth_LocationShouldBeOneSquareFurtherNorth()
			{
				const string EXPECTED_END_POINT = "3 4 N";

				var _robot = new Domain.Robot.Robot(_renderer, new Point(3, 3), Orientation.North, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceEast_LocationShouldBeOneSquareFurtherEast()
			{
				const string EXPECTED_END_POINT = "4 3 E";

				var _robot = new Domain.Robot.Robot(_renderer, new Point(3, 3), Orientation.East, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceSouth_LocationShouldBeOneSquareFurtherSouth()
			{
				const string EXPECTED_END_POINT = "3 2 S";

				var _robot = new Domain.Robot.Robot(_renderer, new Point(3, 3), Orientation.South, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceWest_LocationShouldBeOneSquareFurtherWest()
			{
				const string EXPECTED_END_POINT = "2 3 W";

				var _robot = new Domain.Robot.Robot(_renderer, new Point(3, 3), Orientation.West, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}


		}

		public class WhenMovingOutsideOfArena
		{
			[Test]
			public void MovingTooFarNorth_ShouldThrowAppropriateException()
			{
				var _robot = new Domain.Robot.Robot(_renderer, new Point(0, ARENA_HEIGHT), Orientation.North, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);


				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}

			[Test]
			public void MovingTooFarEast_ShouldThrowAppropriateException()
			{
				var _robot = new Domain.Robot.Robot(_renderer, new Point(ARENA_WIDTH, 0), Orientation.East, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);


				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}

			[Test]
			public void MovingTooFarSouth_ShouldThrowAppropriateException()
			{
				var _robot = new Domain.Robot.Robot(_renderer, new Point(0, 0), Orientation.South, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}

			[Test]
			public void MovingTooFarWest_ShouldThrowAppropriateException()
			{
				var _robot = new Domain.Robot.Robot(_renderer, new Point(0, 0), Orientation.West, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}
		}
	}
}
