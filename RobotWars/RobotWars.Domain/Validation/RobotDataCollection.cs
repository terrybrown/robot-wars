using System;
using System.Drawing;
using RobotWars.Domain.Robot;

namespace RobotWars.Domain.Validation
{
	public class RobotDataCollection
	{
		public static Point CollectPosition(Func<string> userInputValueCollector, string dataCollectionMessage, string invalidInputMessage)
		{
			Point position;

			Console.WriteLine(dataCollectionMessage);
			string userInput = userInputValueCollector.Invoke() ?? string.Empty;

			while (!RobotPosition.TryParsePosition(userInput, out position))
			{
				Console.WriteLine(invalidInputMessage);
				Console.WriteLine(dataCollectionMessage);

				userInput = userInputValueCollector.Invoke() ?? string.Empty;
			}

			return position;
		}

		public static string ValidatePreProgrammedMoves(Func<string> userInputValueCollector, string dataCollectionMessage, string invalidInputMessage)
		{
			string moves;

			Console.WriteLine(dataCollectionMessage);
			string userInput = userInputValueCollector.Invoke() ?? string.Empty;

			while (!RobotMoves.TryParseMoves(userInput, out moves))
			{
				Console.WriteLine(invalidInputMessage);
				Console.WriteLine(dataCollectionMessage);

				userInput = userInputValueCollector.Invoke() ?? string.Empty;
			}

			return moves;
		}


		public static Orientation ValidateOrientation(Func<string> userInputValueCollector, string dataCollectionMessage, string invalidInputMessage)
		{
			Orientation orientation;

			Console.WriteLine(dataCollectionMessage);
			string userInput = userInputValueCollector.Invoke() ?? string.Empty;

			while (!RobotOrientation.TryParseOrientation(userInput, out orientation))
			{
				Console.WriteLine(invalidInputMessage);
				Console.WriteLine(dataCollectionMessage);

				userInput = userInputValueCollector.Invoke() ?? string.Empty;
			}

			return orientation;
		}
	}
}