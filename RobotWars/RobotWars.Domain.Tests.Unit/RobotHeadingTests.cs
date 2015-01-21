using NUnit.Framework;

namespace RobotWars.Domain.Tests.Unit
{
	[TestFixture]
	public class RobotHeadingTests
	{
		private const Orientation NORTH = Orientation.North;
		private const Orientation EAST	= Orientation.East;
		private const Orientation SOUTH = Orientation.South;
		private const Orientation WEST	= Orientation.West;

		public class WithoutAnyTurnCommands
		{
			[Test]
			public void AndInitialHeadingOfNorth_GetHeadingShouldReturnNorth()
			{
				var _heading = new RobotHeading(NORTH);

				Assert.AreEqual(_heading.GetHeading(), "N");
			}

			[Test]
			public void AndInitialHeadingOfSouth_GetHeadingShouldReturnSouth()
			{
				var _heading = new RobotHeading(SOUTH);

				Assert.AreEqual("S", _heading.GetHeading());
			}
		}

		public class WhenTurningLeft
		{
			[Test]
			public void WhenInitialHeadingIsNorth_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(NORTH);

				_heading.TurnLeft();

				Assert.AreEqual("W", _heading.GetHeading());
			}

			[Test]
			public void WhenInitialHeadingIsWest_GetHeadingWillReturnSouth()
			{
				var _heading = new RobotHeading(WEST);

				_heading.TurnLeft();

				Assert.AreEqual("S", _heading.GetHeading());
			}

			[Test]
			public void WhenInitialHeadingIsSouth_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(SOUTH);

				_heading.TurnLeft();

				Assert.AreEqual("E", _heading.GetHeading());
			}

			[Test]
			public void WhenInitialHeadingIsEast_GetHeadingWillReturnNorth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft();

				Assert.AreEqual("N", _heading.GetHeading());
			}

			[Test]
			public void WhenTurningTwiceAndInitialHeadingIsEast_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft().TurnLeft();

				Assert.AreEqual("W", _heading.GetHeading());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialHeadingIsEast_GetHeadingWillReturnSouth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("S", _heading.GetHeading());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialHeadingIsEast_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft().TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("E", _heading.GetHeading());
			}

		}

		public class WhenTurningRight
		{
			[Test]
			public void WhenInitialHeadingIsNorth_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(NORTH);

				_heading.TurnRight();

				Assert.AreEqual("E", _heading.GetHeading());
			}

			[Test]
			public void WhenInitialHeadingIsWest_GetHeadingWillReturnNorth()
			{
				var _heading = new RobotHeading(WEST);

				_heading.TurnRight();

				Assert.AreEqual("N", _heading.GetHeading());
			}

			[Test]
			public void WhenInitialHeadingIsSouth_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(SOUTH);

				_heading.TurnRight();

				Assert.AreEqual("W", _heading.GetHeading());
			}

			[Test]
			public void WhenInitialHeadingIsEast_GetHeadingWillReturnSouth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight();

				Assert.AreEqual("S", _heading.GetHeading());
			}

			[Test]
			public void WhenTurningTwiceAndInitialHeadingIsEast_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight().TurnRight();

				Assert.AreEqual("W", _heading.GetHeading());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialHeadingIsEast_GetHeadingWillReturnNorth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("N", _heading.GetHeading());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialHeadingIsEast_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight().TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("E", _heading.GetHeading());
			}

		}
	}
}