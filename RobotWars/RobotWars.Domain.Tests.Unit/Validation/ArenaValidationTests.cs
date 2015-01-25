using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RobotWars.Domain.Validation;

namespace RobotWars.Domain.Tests.Unit.Validation
{
	[TestFixture]
	public class ArenaValidationTests
	{
		public class WithBadArenaDimensionInput
		{
			private const int VALID_ARENA_DIMENSION = 5;
			private const int TOO_LOW_ARENA_DIMENSION = 0;
			private const int TOO_HIGH_ARENA_DIMENSION = 101;
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
			public void GivenNullAsDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				_inputs.Enqueue(null);
				_inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());
				
				int _arenaDimension = GameDataCollection.ValidateArenaDimension(_userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenStringAsDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				_inputs.Enqueue("A");
				_inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int _arenaDimension = GameDataCollection.ValidateArenaDimension(_userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenWhitespaceAsDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				_inputs.Enqueue(" ");
				_inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int _arenaDimension = GameDataCollection.ValidateArenaDimension(_userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenContinuallyBadData_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				_inputs.Enqueue(" ");
				_inputs.Enqueue("A");
				_inputs.Enqueue(null);
				_inputs.Enqueue(" ");
				_inputs.Enqueue("A");
				_inputs.Enqueue(null);
				_inputs.Enqueue(" ");
				_inputs.Enqueue("A");
				_inputs.Enqueue(null);
				_inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int _arenaDimension = GameDataCollection.ValidateArenaDimension(_userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(10));
			}

			[Test]
			public void GivenTooHighAnArenaDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				_inputs.Enqueue(TOO_HIGH_ARENA_DIMENSION.ToString());
				_inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int _arenaDimension = GameDataCollection.ValidateArenaDimension(_userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenTooLowAnArenaDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				_inputs.Enqueue(TOO_LOW_ARENA_DIMENSION.ToString());
				_inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int _arenaDimension = GameDataCollection.ValidateArenaDimension(_userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, _arenaDimension);
				_userInputCollector.Verify(x => x(), Times.Exactly(2));
			}
		}
	}
}