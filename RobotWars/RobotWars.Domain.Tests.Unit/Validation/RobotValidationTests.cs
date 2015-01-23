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

			Mock<Func<string>> _userInputCollector;
			readonly Queue<string> _inputs = new Queue<string>();

			[SetUp]
			public void BeforeEachTest()
			{
				_inputs.Clear();
				_userInputCollector = new Mock<Func<string>>();
				_userInputCollector.Setup( x => x() ).Returns(() => _inputs.Dequeue());
			}

			[TearDown]
			public void AfterEachTest()
			{
				_userInputCollector = null;	
			}

			[Test]
			public void GivenNullAsPoint_ThenValidPoint_ShouldReturnCorrectPoint()
			{
				_inputs.Enqueue(null);
				_inputs.Enqueue(ValidArenaDimension);
				
				Point _arenaDimension = RobotDataCollection.CollectPosition(_userInputCollector.Object, "", "");

				Assert.AreEqual(ValidRobotPositionAsPoint, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenPointWithoutAComma_ThenValidPoint_ShouldReturnCorrectPoint()
			{
				_inputs.Enqueue("6 6");
				_inputs.Enqueue(ValidArenaDimension);
				
				Point _arenaDimension = RobotDataCollection.CollectPosition(_userInputCollector.Object, "", "");

				Assert.AreEqual(ValidRobotPositionAsPoint, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenPointWithNoNumbers_ThenValidPoint_ShouldReturnCorrectPoint()
			{
				_inputs.Enqueue("A,B");
				_inputs.Enqueue(ValidArenaDimension);
				
				Point _arenaDimension = RobotDataCollection.CollectPosition(_userInputCollector.Object, "", "");

				Assert.AreEqual(ValidRobotPositionAsPoint, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenPointWithTooManyElements_ShouldIgnoreExtraElements_AndReturnCorrectPoint()
			{
				Point _expectedOutput = new Point(8,8);
				_inputs.Enqueue(string.Format("{0},{1},A,B,C,D",
					_expectedOutput.X,
					_expectedOutput.Y));
				_inputs.Enqueue(ValidArenaDimension);
				
				Point _arenaDimension = RobotDataCollection.CollectPosition(_userInputCollector.Object, "", "");

				Assert.AreEqual(_expectedOutput, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Once);
			}

		}


		public class WhenAcceptingPreProgrammedMovesForTheRobot
		{
			private const string VALID_ROBOT_MOVES = "MLMRMLMR";

			Mock<Func<string>> _userInputCollector;
			readonly Queue<string> _inputs = new Queue<string>();

			[SetUp]
			public void BeforeEachTest()
			{
				_inputs.Clear();
				_userInputCollector = new Mock<Func<string>>();
				_userInputCollector.Setup( x => x() ).Returns(() => _inputs.Dequeue());
			}

			[TearDown]
			public void AfterEachTest()
			{
				_userInputCollector = null;	
			}

			[Test]
			public void GivenNullAsMoves_ThenValidMoves_ShouldReturnCorrectMoves()
			{
				_inputs.Enqueue(null);
				_inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string _moves = RobotDataCollection.ValidatePreProgrammedMoves(_userInputCollector.Object, "", "");

				Assert.AreEqual(VALID_ROBOT_MOVES, _moves);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenMovesWithSpaces_ShouldReturnCorrectMovesWithSpacesRemoved()
			{
				_inputs.Enqueue(" " + string.Join(" ", VALID_ROBOT_MOVES.ToArray()) + " ");
				
				string _moves = RobotDataCollection.ValidatePreProgrammedMoves(_userInputCollector.Object, "", "");

				Assert.AreEqual(VALID_ROBOT_MOVES, _moves);
				_userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenMovesWithNoValidMoves_ThenValidMoves_ShouldReturnCorrectMoves()
			{
				_inputs.Enqueue("ABCDEFGHIJKNOPQSTUVWXYZ");
				_inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string _moves = RobotDataCollection.ValidatePreProgrammedMoves(_userInputCollector.Object, "", "");

				Assert.AreEqual(VALID_ROBOT_MOVES, _moves);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenMovesWithInvalidMovesIncluded_ShouldIgnoreInvalidMoves_AndReturnCorrectMoves()
			{
				string _input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				string _expectedOutput = Regex.Replace(_input, "[^LMR]", "", RegexOptions.IgnoreCase);

				_inputs.Enqueue(_input);
				_inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string _moves = RobotDataCollection.ValidatePreProgrammedMoves(_userInputCollector.Object, "", "");

				Assert.AreEqual(_expectedOutput, _moves);
				_userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenASingleMoveOnly_ShouldReturnCorrectMoves()
			{
				string _input = "M";

				_inputs.Enqueue(_input);
				_inputs.Enqueue(VALID_ROBOT_MOVES);
				
				string _moves = RobotDataCollection.ValidatePreProgrammedMoves(_userInputCollector.Object, "", "");

				Assert.AreEqual(_input, _moves);
				_userInputCollector.Verify(x => x(), Times.Once);
			}
		}
	}
}