using System.Drawing;
using NUnit.Framework;

namespace RobotWars.Domain.Tests.Unit
{
	[TestFixture]
	public class RobotTests
	{
		static readonly Point ArenaSize = new Point(10, 10);
 
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
	}
}
