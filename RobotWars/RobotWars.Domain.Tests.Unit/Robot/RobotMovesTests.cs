using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;
using RobotWars.Domain.Robot;
using RobotWars.Domain.Validation;

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
				string _input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				string _expectedOutput = Regex.Replace(_input, "[^LMR]", "", RegexOptions.IgnoreCase);

				var _robotMoves = new RobotMoves(_input);

				Assert.AreEqual(_expectedOutput, _robotMoves.ToString());
			}

			[Test]
			public void GivenASingleMoveOnly_ShouldReturnCorrectMoves()
			{
				string _input = "M";
				
				var _robotMoves = new RobotMoves(_input);

				Assert.AreEqual(_input, _robotMoves.ToString());
			}

			[Test]
			public void GivenMovesWithSpaces_ShouldIgnoreSpaces_AndReturnCorrectMoves()
			{
				var _input = " " + string.Join(" ", VALID_ROBOT_MOVES.ToArray()) + " ";
				
				var _robotMoves = new RobotMoves(_input);

				Assert.AreEqual(VALID_ROBOT_MOVES, _robotMoves.ToString());
			}
		}
	}
}