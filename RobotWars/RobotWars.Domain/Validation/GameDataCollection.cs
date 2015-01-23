using System;

namespace RobotWars.Domain.Validation
{
	public static class GameDataCollection
	{
		public static int ValidateArenaDimension(Func<string> userInputValueCollector, string dataCollectionMessage, string invalidInputMessage)
		{
			int _dimension;

			Console.WriteLine(dataCollectionMessage);
			string _userInput = userInputValueCollector.Invoke() ?? string.Empty;

			while (!IsValidArenaDimension(_userInput, out _dimension))
			{
				Console.WriteLine(invalidInputMessage);
				Console.WriteLine(dataCollectionMessage);

				_userInput = userInputValueCollector.Invoke() ?? string.Empty;
			}

			return _dimension;
		}
		
		/// <summary>
		/// Arena dimensions from 1-100 are abitrary here - realistically, we'd want nice polygon handling for the arena
		/// this is just an indication of a 'business rule' type scenario
		/// </summary>
		private static bool IsValidArenaDimension(string userInput, out int parsedArenaDimension)
		{
			return int.TryParse(userInput.Trim(), out parsedArenaDimension) && parsedArenaDimension > 0 && parsedArenaDimension <= 100;
		}
	}
}