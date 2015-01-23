using System;
using System.Drawing;
using System.Text.RegularExpressions;
using RobotWars.Domain.Robot;

namespace RobotWars.Domain.Validation
{
	public class RobotDataCollection
	{
		public static Point CollectPosition(Func<string> userInputValueCollector, string dataCollectionMessage, string invalidInputMessage)
		{
			Point _position;

			Console.WriteLine(dataCollectionMessage);
			string _userInput = userInputValueCollector.Invoke() ?? string.Empty;

			while (!RobotPosition.TryParsePosition(_userInput, out _position))
			{
				Console.WriteLine(invalidInputMessage);
				Console.WriteLine(dataCollectionMessage);

				_userInput = userInputValueCollector.Invoke() ?? string.Empty;
			}

			return _position;
		}

		public static string ValidatePreProgrammedMoves(Func<string> userInputValueCollector, string dataCollectionMessage, string invalidInputMessage)
		{
			string _moves;

			Console.WriteLine(dataCollectionMessage);
			string _userInput = userInputValueCollector.Invoke() ?? string.Empty;

			while (!RobotMoves.TryParseMoves(_userInput, out _moves))
			{
				Console.WriteLine(invalidInputMessage);
				Console.WriteLine(dataCollectionMessage);

				_userInput = userInputValueCollector.Invoke() ?? string.Empty;
			}

			return _moves;
		}


		public static Orientation ValidateOrientation(Func<string> userInputValueCollector, string dataCollectionMessage, string invalidInputMessage)
		{
			Orientation _orientation;

			Console.WriteLine(dataCollectionMessage);
			string _userInput = userInputValueCollector.Invoke() ?? string.Empty;

			while (!RobotOrientation.TryParseOrientation(_userInput, out _orientation))
			{
				Console.WriteLine(invalidInputMessage);
				Console.WriteLine(dataCollectionMessage);

				_userInput = userInputValueCollector.Invoke() ?? string.Empty;
			}

			return _orientation;
		}
	}
}