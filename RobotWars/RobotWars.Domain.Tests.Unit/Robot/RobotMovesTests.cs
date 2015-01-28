using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RobotWars.Domain.Robot;

namespace RobotWars.Domain.Tests.Unit.Robot
{
	public class RobotMovesTests
	{
		public class WhenGettingMoves
		{
			private const string VALID_ROBOT_MOVES = "MLMRMLMR";

			[Test]
			public void GivenNullAsMoves_ShouldThrowException()
			{
				Assert.Throws<ArgumentOutOfRangeException>(() => new RobotMoves(null));
			}

			[Test]
			public void GivenMovesWithNoValidMoves_ShouldThrowException()
			{
				Assert.Throws<ArgumentOutOfRangeException>(() => new RobotMoves("ABCDEFGHIJKNOPQSTUVWXYZ"));
			}

			[Test]
			public void GivenMovesWithInvalidMovesIncluded_ShouldIgnoreInvalidMoves_AndReturnCorrectMoves()
			{
				const string INPUT = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				string expectedOutput = Regex.Replace(INPUT, "[^LMR]", "", RegexOptions.IgnoreCase);

				var robotMoves = new RobotMoves(INPUT);

				Assert.AreEqual(expectedOutput, robotMoves.ToString());
			}

			[Test]
			public void GivenASingleMoveOnly_ShouldReturnCorrectMoves()
			{
				const string INPUT = "M";
				
				var robotMoves = new RobotMoves(INPUT);

				Assert.AreEqual(INPUT, robotMoves.ToString());
			}

			[Test]
			public void GivenMovesWithSpaces_ShouldIgnoreSpaces_AndReturnCorrectMoves()
			{
				var input = " " + string.Join(" ", VALID_ROBOT_MOVES.ToArray()) + " ";
				
				var robotMoves = new RobotMoves(input);

				Assert.AreEqual(VALID_ROBOT_MOVES, robotMoves.ToString());
			}
		}
	}
}