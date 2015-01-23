using System;

namespace RobotWars.Domain.Validation
{
	public class GeneralDataCollection
	{
		public static bool DoesInputMatchSuccessValue(Func<string> userInputValueCollector, string successValue)
		{
			string _userInput = userInputValueCollector.Invoke() ?? string.Empty;

			return _userInput.Equals(successValue, StringComparison.InvariantCultureIgnoreCase);

		}
	}
}