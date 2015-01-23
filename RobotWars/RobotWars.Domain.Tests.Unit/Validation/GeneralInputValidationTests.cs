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
			public void GivenNullAsInput_ShouldReturnFalse()
			{
				_inputs.Enqueue(null);
				
				Assert.IsFalse(GeneralDataCollection.DoesInputMatchSuccessValue(_userInputCollector.Object, SUCCESS_INPUT));
				_userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenNonSuccessInput_ShouldReturnFalse()
			{
				_inputs.Enqueue("N");
				
				Assert.IsFalse(GeneralDataCollection.DoesInputMatchSuccessValue(_userInputCollector.Object, SUCCESS_INPUT));
				_userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenSuccessInputInLowercase_ShouldReturnTrue()
			{
				_inputs.Enqueue(SUCCESS_INPUT.ToLowerInvariant());
				
				Assert.IsTrue(GeneralDataCollection.DoesInputMatchSuccessValue(_userInputCollector.Object, SUCCESS_INPUT));
				_userInputCollector.Verify(x => x(), Times.Once);
			}

			[Test]
			public void GivenSuccessInputInUppercase_ShouldReturnTrue()
			{
				_inputs.Enqueue(SUCCESS_INPUT.ToUpperInvariant());
				
				Assert.IsTrue(GeneralDataCollection.DoesInputMatchSuccessValue(_userInputCollector.Object, SUCCESS_INPUT));
				_userInputCollector.Verify(x => x(), Times.Once);
			}
		}
	}
}