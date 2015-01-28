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
			public void GivenNullAsDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				inputs.Enqueue(null);
				inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());
				
				int arenaDimension = GameDataCollection.ValidateArenaDimension(userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenStringAsDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				inputs.Enqueue("A");
				inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int arenaDimension = GameDataCollection.ValidateArenaDimension(userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenWhitespaceAsDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				inputs.Enqueue(" ");
				inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int arenaDimension = GameDataCollection.ValidateArenaDimension(userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenContinuallyBadData_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				inputs.Enqueue(" ");
				inputs.Enqueue("A");
				inputs.Enqueue(null);
				inputs.Enqueue(" ");
				inputs.Enqueue("A");
				inputs.Enqueue(null);
				inputs.Enqueue(" ");
				inputs.Enqueue("A");
				inputs.Enqueue(null);
				inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int arenaDimension = GameDataCollection.ValidateArenaDimension(userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(10));
			}

			[Test]
			public void GivenTooHighAnArenaDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				inputs.Enqueue(TOO_HIGH_ARENA_DIMENSION.ToString());
				inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int arenaDimension = GameDataCollection.ValidateArenaDimension(userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}

			[Test]
			public void GivenTooLowAnArenaDimension_ThenValidDimension_ShouldReturnCorrectDimension()
			{
				inputs.Enqueue(TOO_LOW_ARENA_DIMENSION.ToString());
				inputs.Enqueue(VALID_ARENA_DIMENSION.ToString());

				int arenaDimension = GameDataCollection.ValidateArenaDimension(userInputCollector.Object, 
																				"", 
																				"");

				Assert.AreEqual(VALID_ARENA_DIMENSION, arenaDimension);
				userInputCollector.Verify(x => x(), Times.Exactly(2));
			}
		}
	}
}