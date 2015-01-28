using System;
using System.Linq;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain.Robot
{
	public class RobotOrientation
	{
		private readonly IOutputRenderer renderer;
		private Orientation currentOrientation;
		private static readonly Orientation[] ValidOrientations = { Orientation.North, 
																	Orientation.East, 
																	Orientation.South,
																	Orientation.West };

		public RobotOrientation(IOutputRenderer renderer, Orientation orientation = Orientation.North)
		{
			this.renderer = renderer;
			currentOrientation = orientation;
		}

		public RobotOrientation TurnLeft()
		{
			renderer.RenderDebug("Turning left");

			int nextIndex = Array.IndexOf(ValidOrientations, currentOrientation) - 1;
			if (nextIndex < 0)
			{
				nextIndex = ValidOrientations.Length -1;
			}

			currentOrientation = ValidOrientations[nextIndex];
			
			return this;
		}

		public RobotOrientation TurnRight()
		{
			renderer.RenderDebug("Turning right");
	
			int nextIndex = Array.IndexOf(ValidOrientations, currentOrientation) + 1;
			if (nextIndex > ValidOrientations.Length -1)
			{
				nextIndex = 0;
			}

			currentOrientation = ValidOrientations[nextIndex];

			return this;
		}

		public string GetOrientationAsSingleLetterCompassPoint()
		{
			return currentOrientation.ToString().Substring(0, 1);	// better way than this, quick fix for now
		}

		public static bool TryParseOrientation(string inputOrientation, out Orientation orientation)
		{
			if (string.IsNullOrWhiteSpace(inputOrientation))
			{
				orientation = Orientation.North;
				return false;
			}

			Orientation parsedOrientation;
			switch (inputOrientation.Substring(0, 1).ToUpperInvariant())
			{
				case "N":
					parsedOrientation = Orientation.North;
					break;
				case "E":
					parsedOrientation = Orientation.East;
					break;
				case "S":
					parsedOrientation = Orientation.South;
					break;
				case "W":
					parsedOrientation = Orientation.West;
					break;
				default:
					orientation = Orientation.North;
					return false;
					
			}
			orientation = parsedOrientation;

			return ValidOrientations.Any( x => x == parsedOrientation);
		}

		public override string ToString()
		{
			return currentOrientation.ToString();
		}
	}
}