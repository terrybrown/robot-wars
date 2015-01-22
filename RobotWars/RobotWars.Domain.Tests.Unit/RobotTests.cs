using System;
using System.Drawing;
using NUnit.Framework;

namespace RobotWars.Domain.Tests.Unit
{
	[TestFixture]
	public class RobotTests
	{
		private const int ARENA_WIDTH = 10;
		private const int ARENA_HEIGHT = 10;

		static readonly Point ArenaSize = new Point(ARENA_WIDTH, ARENA_HEIGHT);

		public class WhenMovingWithinArenaBounds
		{
			[Test]
			public void OneSpaceNorth_LocationShouldBeOneSquareFurtherNorth()
			{
				const string EXPECTED_END_POINT = "3 4 N";

				Robot _robot = new Robot(3, 3, Orientation.North, "M", ArenaSize);
				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceEast_LocationShouldBeOneSquareFurtherEast()
			{
				const string EXPECTED_END_POINT = "4 3 E";

				Robot _robot = new Robot(3, 3, Orientation.East, "M", ArenaSize);
				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceSouth_LocationShouldBeOneSquareFurtherSouth()
			{
				const string EXPECTED_END_POINT = "3 2 S";

				Robot _robot = new Robot(3, 3, Orientation.South, "M", ArenaSize);
				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceWest_LocationShouldBeOneSquareFurtherWest()
			{
				const string EXPECTED_END_POINT = "2 3 W";

				Robot _robot = new Robot(3, 3, Orientation.West, "M", ArenaSize);
				_robot.MoveForward();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}


		}

		public class WhenMovingOutsideOfArena
		{
			[Test]
			public void MovingTooFarNorth_ShouldThrowAppropriateException()
			{
				Robot _robot = new Robot(0, ARENA_HEIGHT, Orientation.North, "M", ArenaSize);

				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}

			[Test]
			public void MovingTooFarEast_ShouldThrowAppropriateException()
			{
				Robot _robot = new Robot(ARENA_WIDTH, 0, Orientation.East, "M", ArenaSize);

				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}

			[Test]
			public void MovingTooFarSouth_ShouldThrowAppropriateException()
			{
				Robot _robot = new Robot(0, 0, Orientation.South, "M", ArenaSize);

				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}

			[Test]
			public void MovingTooFarWest_ShouldThrowAppropriateException()
			{
				Robot _robot = new Robot(0, 0, Orientation.West, "M", ArenaSize);

				Assert.Throws<ArgumentOutOfRangeException>(() => _robot.MoveForward());
			}
		}
	}
}
