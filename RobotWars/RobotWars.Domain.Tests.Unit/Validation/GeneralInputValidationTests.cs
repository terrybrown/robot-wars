using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RobotWars.Domain.Validation;

namespace RobotWars.Domain.Tests.Unit.Validation
{
	[TestFixture]
	public class GeneralInputValidationTests
	{
		public class DoesInputMatchSuccessValue
		{
			private const string SUCCESS_INPUT = "Y";
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
			public void GivenNullAsInput_ShouldReturnFalse()
			{
				inputs.Enqueue(null);
				
				Assert.IsFalse(GeneralDataCollection.DoesInputMatchSuccessValue(userInputCollector.Object, SUCCESS_INPUT));
				userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenNonSuccessInput_ShouldReturnFalse()
			{
				inputs.Enqueue("N");
				
				Assert.IsFalse(GeneralDataCollection.DoesInputMatchSuccessValue(userInputCollector.Object, SUCCESS_INPUT));
				userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenSuccessInputInLowercase_ShouldReturnTrue()
			{
				inputs.Enqueue(SUCCESS_INPUT.ToLowerInvariant());
				
				Assert.IsTrue(GeneralDataCollection.DoesInputMatchSuccessValue(userInputCollector.Object, SUCCESS_INPUT));
				userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenSuccessInputInUppercase_ShouldReturnTrue()
			{
				inputs.Enqueue(SUCCESS_INPUT.ToUpperInvariant());
				
				Assert.IsTrue(GeneralDataCollection.DoesInputMatchSuccessValue(userInputCollector.Object, SUCCESS_INPUT));
				userInputCollector.Verify(x => x(), Times.Once);
			}
		}
	}
}