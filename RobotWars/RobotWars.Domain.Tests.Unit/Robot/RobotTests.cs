using System;
using System.Drawing;
using Moq;
using NUnit.Framework;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain.Tests.Unit.Robot
{
	[TestFixture]
	public class RobotTests
	{
		private const int ARENA_WIDTH = 5;
		private const int ARENA_HEIGHT = 5;
		private static Mock<IOutputRenderer> renderer;

		static readonly Point ArenaBottomLeft = new Point(0, 0);
		static readonly Point ArenaTopRight = new Point(ARENA_WIDTH, ARENA_HEIGHT);

		public class WhenGivenASpecOnAPieceOfPaper
		{
			[SetUp]
			public void BeforeEachTest()
			{
				renderer = new Mock<IOutputRenderer>();
			}

			[TearDown]
			public void AfterEachTest()
			{
				renderer = null;
			}

			[Test]
			public void PreProgrammedRobotOne_ShouldArriveAtItsDestinationSafely()
			{
				const string EXPECTED_END_POINT = "1 3 N";

				var robot = new Domain.Robot.Robot(renderer.Object, new Point(1, 2), Orientation.North, "LMLMLMLMM");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				PerformRemainingMoves(robot);

				Assert.AreEqual(EXPECTED_END_POINT, robot.ToString());
			}

			[Test]
			public void PreProgrammedRobotTwo_ShouldArriveAtItsDestinationSafely()
			{
				const string EXPECTED_END_POINT = "5 1 E";

				var robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.East, "MMRMMRMRRM");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				PerformRemainingMoves(robot);

				Assert.AreEqual(EXPECTED_END_POINT, robot.ToString());
			}
		}

		public class WhenMovingWithinArenaBounds
		{
			[SetUp]
			public void BeforeEachTest()
			{
				renderer = new Mock<IOutputRenderer>();
			}

			[TearDown]
			public void AfterEachTest()
			{
				renderer = null;
			}

			[Test]
			public void OneSpaceNorth_LocationShouldBeOneSquareFurtherNorth()
			{
				const string EXPECTED_END_POINT = "3 4 N";

				var robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.North, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				PerformRemainingMoves(robot);

				Assert.AreEqual(EXPECTED_END_POINT, robot.ToString());
			}

			[Test]
			public void OneSpaceEast_LocationShouldBeOneSquareFurtherEast()
			{
				const string EXPECTED_END_POINT = "4 3 E";

				var robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.East, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				PerformRemainingMoves(robot);

				Assert.AreEqual(EXPECTED_END_POINT, robot.ToString());
			}

			[Test]
			public void OneSpaceSouth_LocationShouldBeOneSquareFurtherSouth()
			{
				const string EXPECTED_END_POINT = "3 2 S";

				var robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.South, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				PerformRemainingMoves(robot);

				Assert.AreEqual(EXPECTED_END_POINT, robot.ToString());
			}

			[Test]
			public void OneSpaceWest_LocationShouldBeOneSquareFurtherWest()
			{
				const string EXPECTED_END_POINT = "2 3 W";

				var robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.West, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				PerformRemainingMoves(robot);

				Assert.AreEqual(EXPECTED_END_POINT, robot.ToString());
			}


		}


		// Arguably, these tests shouldn't be so pervasive - the agreed contract (my spec) is that an attempt to move outside
		// of the arena does nothing and just goes onto the next move - what we are testing below also includes
		// details of the internal implementation, which is less than ideal - I could have gotten away with just the assert
		// here and not mocked the renderer, but I've left the tests in as a discussion point
		public class WhenMovingOutsideOfArena
		{
			[SetUp]
			public void BeforeEachTest()
			{
				renderer = new Mock<IOutputRenderer>();
			}

			[TearDown]
			public void AfterEachTest()
			{
				renderer = null;
			}

			[Test]
			public void MovingTooFarNorth_ShouldThrowAppropriateException()
			{
				var robot = new Domain.Robot.Robot(renderer.Object, new Point(0, ARENA_HEIGHT), Orientation.North, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var startPosition = robot.ToString();

				Assert.Throws<ArgumentOutOfRangeException>(() => robot.PerformNextMove());
				Assert.AreEqual(startPosition, robot.ToString());
			}

			[Test]
			public void MovingTooFarEast_ShouldThrowAppropriateException()
			{
				var robot = new Domain.Robot.Robot(renderer.Object, new Point(ARENA_WIDTH, 0), Orientation.East, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var startPosition = robot.ToString();

				Assert.Throws<ArgumentOutOfRangeException>(() => robot.PerformNextMove());
				Assert.AreEqual(startPosition, robot.ToString());
			}

			[Test]
			public void MovingTooFarSouth_ShouldThrowAppropriateException()
			{
				var robot = new Domain.Robot.Robot(renderer.Object, new Point(0, 0), Orientation.South, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var startPosition = robot.ToString();

				Assert.Throws<ArgumentOutOfRangeException>(() => robot.PerformNextMove());
				Assert.AreEqual(startPosition, robot.ToString());
			}

			[Test]
			public void MovingTooFarWest_ShouldThrowAppropriateException()
			{
				var robot = new Domain.Robot.Robot(renderer.Object, new Point(0, 0), Orientation.West, "M");
				robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var startPosition = robot.ToString();

				Assert.Throws<ArgumentOutOfRangeException>(() => robot.PerformNextMove());
				Assert.AreEqual(startPosition, robot.ToString());
			}
		}

		public class WhenAttemptingToMoveWithoutSettingTheArena
		{
			[SetUp]
			public void BeforeEachTest()
			{
				renderer = new Mock<IOutputRenderer>();
			}

			[TearDown]
			public void AfterEachTest()
			{
				renderer = null;
			}

			[Test]
			public void AnyMovement_ShouldThrowAppropriateException()
			{
				var robot = new Domain.Robot.Robot(renderer.Object, new Point(0, ARENA_HEIGHT), Orientation.North, "M");

				Assert.Throws<ArgumentNullException>(() => PerformRemainingMoves(robot));
			}
		}


		private static void PerformRemainingMoves(Domain.Robot.Robot robot)
		{
			while (robot.HasMovesRemaining())
			{
				robot.PerformNextMove();
			}
		}
	}
}
