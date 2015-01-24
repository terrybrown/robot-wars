using NUnit.Framework;
using RobotWars.Domain.Robot;

namespace RobotWars.Domain.Tests.Unit
{
	[TestFixture]
	public class RobotOrientationTests
	{
		private const Orientation NORTH = Orientation.North;
		private const Orientation EAST	= Orientation.East;
		private const Orientation SOUTH = Orientation.South;
		private const Orientation WEST	= Orientation.West;
		private static readonly NullRenderer Renderer = new NullRenderer();

		public class WithoutAnyTurnCommands
		{
			[Test]
			public void AndInitialOrientationOfNorth_GetOrientationShouldReturnNorth()
			{
				var _orientation = new RobotOrientation(Renderer, NORTH);

				Assert.AreEqual(_orientation.GetOrientationAsSingleLetterCompassPoint(), "N");
			}

			[Test]
			public void AndInitialOrientationOfSouth_GetOrientationShouldReturnSouth()
			{
				var _orientation = new RobotOrientation(Renderer, SOUTH);

				Assert.AreEqual("S", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}
		}

		public class WhenTurningLeft
		{
			[Test]
			public void WhenInitialOrientationIsNorth_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(Renderer, NORTH);

				_orientation.TurnLeft();

				Assert.AreEqual("W", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsWest_GetOrientationWillReturnSouth()
			{
				var _orientation = new RobotOrientation(Renderer, WEST);

				_orientation.TurnLeft();

				Assert.AreEqual("S", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsSouth_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(Renderer, SOUTH);

				_orientation.TurnLeft();

				Assert.AreEqual("E", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsEast_GetOrientationWillReturnNorth()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnLeft();

				Assert.AreEqual("N", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningTwiceAndInitialOrientationIsEast_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnLeft().TurnLeft();

				Assert.AreEqual("W", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialOrientationIsEast_GetOrientationWillReturnSouth()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("S", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialOrientationIsEast_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnLeft().TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("E", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

		}

		public class WhenTurningRight
		{
			[Test]
			public void WhenInitialOrientationIsNorth_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(Renderer, NORTH);

				_orientation.TurnRight();

				Assert.AreEqual("E", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsWest_GetOrientationWillReturnNorth()
			{
				var _orientation = new RobotOrientation(Renderer, WEST);

				_orientation.TurnRight();

				Assert.AreEqual("N", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsSouth_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(Renderer, SOUTH);

				_orientation.TurnRight();

				Assert.AreEqual("W", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsEast_GetOrientationWillReturnSouth()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnRight();

				Assert.AreEqual("S", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningTwiceAndInitialOrientationIsEast_GetOrientationWillReturnWest()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnRight().TurnRight();

				Assert.AreEqual("W", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialOrientationIsEast_GetOrientationWillReturnNorth()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("N", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialOrientationIsEast_GetOrientationWillReturnEast()
			{
				var _orientation = new RobotOrientation(Renderer, EAST);

				_orientation.TurnRight().TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("E", _orientation.GetOrientationAsSingleLetterCompassPoint());
			}

		}
	}
}