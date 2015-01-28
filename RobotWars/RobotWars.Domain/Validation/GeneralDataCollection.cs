using System;

namespace RobotWars.Domain.Validation
{
	public class GeneralDataCollection
	{
		public static bool DoesInputMatchSuccessValue(Func<string> userInputValueCollector, string successValue)
		{
			string userInput = userInputValueCollector.Invoke() ?? string.Empty;

			return userInput.Equals(successValue, StringComparison.InvariantCultureIgnoreCase);

		}
	}
}