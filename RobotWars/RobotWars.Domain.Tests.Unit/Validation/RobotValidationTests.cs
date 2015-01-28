using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;
using RobotWars.Domain.Validation;

namespace RobotWars.Domain.Tests.Unit.Validation
{
	[TestFixture]
	public class RobotValidationTests
	{
		public class WhenCreatingRobotPosition
		{
			private static readonly Point ValidRobotPositionAsPoint = new Point(5,5);
			private static readonly string ValidArenaDimension		= string.Format("{0},{1}", ValidRobotPositionAsPoint.X, ValidRobotPositionAsPoint.Y);

			Mock<Func<string>> userInputCollector;
			readonly Queue<string> inputs = new Queue<string>();

			[SetUp]
			public void BeforeEachTest()
			{
				inputs.Clear();
				userInputCollector = new Mock<Func<string>>();
				userInputCollector.Setup( x => x() ).Returns(() => inputs.Dequeue());
			}

			[TearDown]
			public void AfterEachTest()
			{
				userInputCollector = null;	
			}

			[Test]
			public void GivenNullAsPoint_ThenValidPoint_ShouldReturnCorrectPoint()
			{
				inputs.Enqueue(null);
				inputs.Enqueue(ValidArenaDimension);
				
				Point arenaDimension = RobotDataCollection.CollectPosition(userInputCollector.Object, "", "");

				Assert.AreEqual(ValidRobotPositionAsPoint, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenPointWithoutAComma_ThenValidPoint_ShouldReturnCorrectPoint()
			{
				inputs.Enqueue("6 6");
				inputs.Enqueue(ValidArenaDimension);
				
				Point arenaDimension = RobotDataCollection.CollectPosition(userInputCollector.Object, "", "");

				Assert.AreEqual(ValidRobotPositionAsPoint, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenPointWithNoNumbers_ThenValidPoint_ShouldReturnCorrectPoint()
			{
				inputs.Enqueue("A,B");
				inputs.Enqueue(ValidArenaDimension);
				
				Point arenaDimension = RobotDataCollection.CollectPosition(userInputCollector.Object, "", "");

				Assert.AreEqual(ValidRobotPositionAsPoint, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenPointWithTooManyElements_ShouldIgnoreExtraElements_AndReturnCorrectPoint()
			{
				Point expectedOutput = new Point(8,8);
				inputs.Enqueue(string.Format("{0},{1},A,B,C,D",
					expectedOutput.X,
					expectedOutput.Y));
				inputs.Enqueue(ValidArenaDimension);
				
				Point arenaDimension = RobotDataCollection.CollectPosition(userInputCollector.Object, "", "");

				Assert.AreEqual(expectedOutput, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Once);
			}

		}


		public class WhenAcceptingPreProgrammedMovesForTheRobot
		{
			private const string VALID_ROBOT_MOVES = "MLMRMLMR";

			Mock<Func<string>> userInputCollector;
			readonly Queue<string> inputs = new Queue<string>();

			[SetUp]
			public void BeforeEachTest()
			{
				inputs.Clear();
				userInputCollector = new Mock<Func<string>>();
				userInputCollector.Setup( x => x() ).Returns(() => inputs.Dequeue());
			}

			[TearDown]
			public void AfterEachTest()
			{
				userInputCollector = null;	
			}

			[Test]
			public void GivenNullAsMoves_ThenValidMoves_ShouldReturnCorrectMoves()
			{
				inputs.Enqueue(null);
				inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string moves = RobotDataCollection.ValidatePreProgrammedMoves(userInputCollector.Object, "", "");

				Assert.AreEqual(VALID_ROBOT_MOVES, moves);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenMovesWithSpaces_ShouldReturnCorrectMovesWithSpacesRemoved()
			{
				inputs.Enqueue(" " + string.Join(" ", VALID_ROBOT_MOVES.ToArray()) + " ");
				
				string moves = RobotDataCollection.ValidatePreProgrammedMoves(userInputCollector.Object, "", "");

				Assert.AreEqual(VALID_ROBOT_MOVES, moves);
				userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenMovesWithNoValidMoves_ThenValidMoves_ShouldReturnCorrectMoves()
			{
				inputs.Enqueue("ABCDEFGHIJKNOPQSTUVWXYZ");
				inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string moves = RobotDataCollection.ValidatePreProgrammedMoves(userInputCollector.Object, "", "");

				Assert.AreEqual(VALID_ROBOT_MOVES, moves);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenMovesWithInvalidMovesIncluded_ShouldIgnoreInvalidMoves_AndReturnCorrectMoves()
			{
				const string INPUT = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				string expectedOutput = Regex.Replace(INPUT, "[^LMR]", "", RegexOptions.IgnoreCase);

				inputs.Enqueue(INPUT);
				inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string moves = RobotDataCollection.ValidatePreProgrammedMoves(userInputCollector.Object, "", "");

				Assert.AreEqual(expectedOutput, moves);
				userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenASingleMoveOnly_ShouldReturnCorrectMoves()
			{
				const string INPUT = "M";

				inputs.Enqueue(INPUT);
				inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string moves = RobotDataCollection.ValidatePreProgrammedMoves(userInputCollector.Object, "", "");

				Assert.AreEqual(INPUT, moves);
				userInputCollector.Verify(x => x(), Times.Once);
			}
		}
	}
}