using NUnit.Framework;

namespace RobotWars.Domain.Tests.Unit
{
	[TestFixture]
	public class RobotOrientationTests
	{
		private const Orientation NORTH = Orientation.North;
		private const Orientation EAST	= Orientation.East;
		private const Orientation SOUTH = Orientation.South;
		private const Orientation WEST	= Orientation.West;

		public class WithoutAnyTurnCommands
		{
			[Test]
			public void AndInitialOrientationOfNorth_GetOrientationShouldReturnNorth()
			{
				var _orientation = new RobotOrientation(NORTH);

				Assert.AreEqual(_orientation.GetOrientation(), "N");
			}

			[Test]
			public void AndInitialOrientationOfSouth_GetOrientationShouldReturnSouth()
			{
				var _orientation = new RobotOrientation(SOUTH);

				Assert.AreEqual("S", _orientation.GetOrientation());
			}
		}

		public class WhenTurningLeft
		{
			[Test]
			public void WhenInitialOrientationIsNorth_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(NORTH);

				_orientation.TurnLeft();

				Assert.AreEqual("W", _orientation.GetOrientation());
			}

			[Test]
			public void WhenInitialOrientationIsWest_GetOrientationWillReturnSouth()
			{
				var _orientation = new RobotOrientation(WEST);

				_orientation.TurnLeft();

				Assert.AreEqual("S", _orientation.GetOrientation());
			}

			[Test]
			public void WhenInitialOrientationIsSouth_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(SOUTH);

				_orientation.TurnLeft();

				Assert.AreEqual("E", _orientation.GetOrientation());
			}

			[Test]
			public void WhenInitialOrientationIsEast_GetOrientationWillReturnNorth()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnLeft();

				Assert.AreEqual("N", _orientation.GetOrientation());
			}

			[Test]
			public void WhenTurningTwiceAndInitialOrientationIsEast_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnLeft().TurnLeft();

				Assert.AreEqual("W", _orientation.GetOrientation());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialOrientationIsEast_GetOrientationWillReturnSouth()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("S", _orientation.GetOrientation());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialOrientationIsEast_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnLeft().TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("E", _orientation.GetOrientation());
			}

		}

		public class WhenTurningRight
		{
			[Test]
			public void WhenInitialOrientationIsNorth_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(NORTH);

				_orientation.TurnRight();

				Assert.AreEqual("E", _orientation.GetOrientation());
			}

			[Test]
			public void WhenInitialOrientationIsWest_GetOrientationWillReturnNorth()
			{
				var _orientation = new RobotOrientation(WEST);

				_orientation.TurnRight();

				Assert.AreEqual("N", _orientation.GetOrientation());
			}

			[Test]
			public void WhenInitialOrientationIsSouth_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(SOUTH);

				_orientation.TurnRight();

				Assert.AreEqual("W", _orientation.GetOrientation());
			}

			[Test]
			public void WhenInitialOrientationIsEast_GetOrientationWillReturnSouth()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnRight();

				Assert.AreEqual("S", _orientation.GetOrientation());
			}

			[Test]
			public void WhenTurningTwiceAndInitialOrientationIsEast_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnRight().TurnRight();

				Assert.AreEqual("W", _orientation.GetOrientation());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialOrientationIsEast_GetOrientationWillReturnNorth()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("N", _orientation.GetOrientation());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialOrientationIsEast_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(EAST);

				_orientation.TurnRight().TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("E", _orientation.GetOrientation());
			}

		}
	}
}