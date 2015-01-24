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

				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(1, 2), Orientation.North, "LMLMLMLMM");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}	

			[Test]
			public void PreProgrammedRobotTwo_ShouldArriveAtItsDestinationSafely()
			{
				const string EXPECTED_END_POINT = "5 1 E";

				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.East, "MMRMMRMRRM");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
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

				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.North, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceEast_LocationShouldBeOneSquareFurtherEast()
			{
				const string EXPECTED_END_POINT = "4 3 E";

				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.East, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceSouth_LocationShouldBeOneSquareFurtherSouth()
			{
				const string EXPECTED_END_POINT = "3 2 S";

				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.South, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
			}

			[Test]
			public void OneSpaceWest_LocationShouldBeOneSquareFurtherWest()
			{
				const string EXPECTED_END_POINT = "2 3 W";

				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(3, 3), Orientation.West, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(EXPECTED_END_POINT, _robot.ToString());
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
			public void MovingTooFarNorth_ShouldOutputWarningAndPositionRemainTheSame()
			{
				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(0, ARENA_HEIGHT), Orientation.North, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var _existingPosition = _robot.ToString();

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(_existingPosition, _robot.ToString());
				renderer.Verify(x => x.RenderError(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
			}

			[Test]
			public void MovingTooFarEast_ShouldOutputWarningAndPositionRemainTheSame()
			{
				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(ARENA_WIDTH, 0), Orientation.East, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var _existingPosition = _robot.ToString();

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(_existingPosition, _robot.ToString());
				renderer.Verify(x => x.RenderError(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
			}

			[Test]
			public void MovingTooFarSouth_ShouldOutputWarningAndPositionRemainTheSame()
			{
				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(0, 0), Orientation.South, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var _existingPosition = _robot.ToString();

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(_existingPosition, _robot.ToString());
				renderer.Verify(x => x.RenderError(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
			}

			[Test]
			public void MovingTooFarWest_ShouldOutputWarningAndPositionRemainTheSame()
			{
				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(0, 0), Orientation.West, "M");
				_robot.SetArenaSize(ArenaBottomLeft, ArenaTopRight);
				var _existingPosition = _robot.ToString();

				_robot.PerformProgrammedMoves();

				Assert.AreEqual(_existingPosition, _robot.ToString());
				renderer.Verify(x => x.RenderError(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
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
				var _robot = new Domain.Robot.Robot(renderer.Object, new Point(0, ARENA_HEIGHT), Orientation.North, "M");

				Assert.Throws<ArgumentNullException>(() => _robot.PerformProgrammedMoves());
			}
		}
	}
}
