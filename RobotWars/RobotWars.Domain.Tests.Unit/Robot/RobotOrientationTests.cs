using NUnit.Framework;
using RobotWars.Domain.Robot;

namespace RobotWars.Domain.Tests.Unit.Robot
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
				var orientation = new RobotOrientation(Renderer, NORTH);

				Assert.AreEqual("N", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void AndInitialOrientationOfSouth_GetOrientationShouldReturnSouth()
			{
				var orientation = new RobotOrientation(Renderer, SOUTH);

				Assert.AreEqual("S", orientation.GetOrientationAsSingleLetterCompassPoint());
			}
		}

		public class WhenTurningLeft
		{
			[Test]
			public void WhenInitialOrientationIsNorth_GetOrientationWillReturnWest()
			{
				var orientation = new RobotOrientation(Renderer, NORTH);

				orientation.TurnLeft();

				Assert.AreEqual("W", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsWest_GetOrientationWillReturnSouth()
			{
				var orientation = new RobotOrientation(Renderer, WEST);

				orientation.TurnLeft();

				Assert.AreEqual("S", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsSouth_GetOrientationWillReturnEast()
			{
				var orientation = new RobotOrientation(Renderer, SOUTH);

				orientation.TurnLeft();

				Assert.AreEqual("E", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsEast_GetOrientationWillReturnNorth()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnLeft();

				Assert.AreEqual("N", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningTwiceAndInitialOrientationIsEast_GetOrientationWillReturnWest()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnLeft().TurnLeft();

				Assert.AreEqual("W", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialOrientationIsEast_GetOrientationWillReturnSouth()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("S", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialOrientationIsEast_GetOrientationWillReturnEast()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnLeft().TurnLeft().TurnLeft().TurnLeft();

				Assert.AreEqual("E", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

		}

		public class WhenTurningRight
		{
			[Test]
			public void WhenInitialOrientationIsNorth_GetOrientationWillReturnEast()
			{
				var orientation = new RobotOrientation(Renderer, NORTH);

				orientation.TurnRight();

				Assert.AreEqual("E", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsWest_GetOrientationWillReturnNorth()
			{
				var orientation = new RobotOrientation(Renderer, WEST);

				orientation.TurnRight();

				Assert.AreEqual("N", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsSouth_GetOrientationWillReturnWest()
			{
				var orientation = new RobotOrientation(Renderer, SOUTH);

				orientation.TurnRight();

				Assert.AreEqual("W", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenInitialOrientationIsEast_GetOrientationWillReturnSouth()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnRight();

				Assert.AreEqual("S", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningTwiceAndInitialOrientationIsEast_GetOrientationWillReturnWest()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnRight().TurnRight();

				Assert.AreEqual("W", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningThreeTimesAndInitialOrientationIsEast_GetOrientationWillReturnNorth()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("N", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

			[Test]
			public void WhenTurningFourTimesAndInitialOrientationIsEast_GetOrientationWillReturnEast()
			{
				var orientation = new RobotOrientation(Renderer, EAST);

				orientation.TurnRight().TurnRight().TurnRight().TurnRight();

				Assert.AreEqual("E", orientation.GetOrientationAsSingleLetterCompassPoint());
			}

		}
	}
}