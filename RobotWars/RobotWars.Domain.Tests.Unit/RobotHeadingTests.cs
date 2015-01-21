using NUnit.Framework;

namespace RobotWars.Domain.Tests.Unit
{
	[TestFixture]
	public class RobotHeadingTests
	{
		private const char NORTH = 'N';
		private const char EAST = 'E';
		private const char SOUTH = 'S';
		private const char WEST = 'W';

		public class WithoutAnyTurnCommands
		{
			[Test]
			public void AndInitialHeadingOfNorth_GetHeadingShouldReturnNorth()
			{
				var _heading = new RobotHeading(NORTH);

				Assert.AreEqual(_heading.GetHeading(), NORTH);
			}

			[Test]
			public void AndInitialHeadingOfSouth_GetHeadingShouldReturnSouth()
			{
				var _heading = new RobotHeading(SOUTH);

				Assert.AreEqual(_heading.GetHeading(), SOUTH);
			}
		}

		public class WhenTurningLeft
		{
			[Test]
			public void WhenInitialHeadingIsNorth_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(NORTH);

				_heading.TurnLeft();

				Assert.AreEqual(_heading.GetHeading(), WEST);
			}

			[Test]
			public void WhenInitialHeadingIsWest_GetHeadingWillReturnSouth()
			{
				var _heading = new RobotHeading(WEST);

				_heading.TurnLeft();

				Assert.AreEqual(_heading.GetHeading(), SOUTH);
			}

			[Test]
			public void WhenInitialHeadingIsSouth_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(SOUTH);

				_heading.TurnLeft();

				Assert.AreEqual(_heading.GetHeading(), EAST);
			}

			[Test]
			public void WhenInitialHeadingIsEast_GetHeadingWillReturnNorth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft();

				Assert.AreEqual(_heading.GetHeading(), NORTH);
			}

			[Test]
			public void WhenTurningTwiceAndInitialHeadingIsEast_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft().TurnLeft();

				Assert.AreEqual(_heading.GetHeading(), WEST);
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialHeadingIsEast_GetHeadingWillReturnSouth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual(_heading.GetHeading(), SOUTH);
			}

			[Test]
			public void WhenTurningFourTimesAndInitialHeadingIsEast_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnLeft().TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual(_heading.GetHeading(), EAST);
			}

		}

		public class WhenTurningRight
		{
			[Test]
			public void WhenInitialHeadingIsNorth_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(NORTH);

				_heading.TurnRight();

				Assert.AreEqual(_heading.GetHeading(), EAST);
			}

			[Test]
			public void WhenInitialHeadingIsWest_GetHeadingWillReturnNorth()
			{
				var _heading = new RobotHeading(WEST);

				_heading.TurnRight();

				Assert.AreEqual(_heading.GetHeading(), NORTH);
			}

			[Test]
			public void WhenInitialHeadingIsSouth_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(SOUTH);

				_heading.TurnRight();

				Assert.AreEqual(_heading.GetHeading(), WEST);
			}

			[Test]
			public void WhenInitialHeadingIsEast_GetHeadingWillReturnSouth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight();

				Assert.AreEqual(_heading.GetHeading(), SOUTH);
			}

			[Test]
			public void WhenTurningTwiceAndInitialHeadingIsEast_GetHeadingWillReturnWest()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight().TurnRight();

				Assert.AreEqual(_heading.GetHeading(), WEST);
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialHeadingIsEast_GetHeadingWillReturnNorth()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight().TurnRight().TurnRight();

				Assert.AreEqual(_heading.GetHeading(), NORTH);
			}

			[Test]
			public void WhenTurningFourTimesAndInitialHeadingIsEast_GetHeadingWillReturnEast()
			{
				var _heading = new RobotHeading(EAST);

				_heading.TurnRight().TurnRight().TurnRight().TurnRight();

				Assert.AreEqual(_heading.GetHeading(), EAST);
			}

		}
	}
}