using System;
using System.Drawing;
using RobotWars.Application.Properties;
using RobotWars.Application.Renderers;
using RobotWars.Domain;
using RobotWars.Domain.Contracts;
using RobotWars.Domain.Robot;
using RobotWars.Domain.Validation;

namespace RobotWars.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			var renderer = new ConsoleRenderer(Settings.Default.RenderDebugOutput);

			renderer.RenderOutput("Robot Wars ---------------------------------------");
			renderer.RenderOutput("Verbose output is set to '{0}' - you can change it in app.config", Settings.Default.RenderDebugOutput);
			renderer.RenderOutput("");

			int arenaWidth	= GameDataCollection.ValidateArenaDimension(renderer.ReadInput, 
																	"Please enter the arena width", 
																	"That's not a valid width - please enter a number between 1 and 100");
			int arenaHeigth = GameDataCollection.ValidateArenaDimension(renderer.ReadInput, 
																	"Please enter the arena height", 
																	"That's not a valid height - please enter a number between 1 and 100");

			var game = new RobotWarsGame(renderer, new GameArena(arenaWidth, arenaHeigth));

			renderer.RenderOutput("Robot Factory ---------------------------------------");
			bool addAnotherRobot = true;
			while (addAnotherRobot)
			{
				// collect first robot details here
				CollectAndBuildRobot(renderer, game);

				renderer.RenderOutput("");
				renderer.RenderOutput("Add another robot?");
				addAnotherRobot = GeneralDataCollection.DoesInputMatchSuccessValue(renderer.ReadInput, "Y");
			}

			game.PlayGame();

			Console.ForegroundColor = ConsoleColor.Cyan;
			renderer.RenderOutput("Final Positions ------------------------------------------------");
			
			game.GetFinalPositions();

			Console.ReadKey();
		}

		private static void CollectAndBuildRobot(ConsoleRenderer renderer, RobotWarsGame game)
		{

			Point positionOnArena = RobotDataCollection.CollectPosition(renderer.ReadInput, 
													"Please enter the robot's position on the arena in X,Y format:",
													"That's not a valid position - please enter in the format X,Y"
													);



			Orientation robotOrientation = RobotDataCollection.ValidateOrientation(renderer.ReadInput,
													"Please enter the robots orientation as a compass point (N, E, S, W):",
													"That is not a valid compass point");


			renderer.RenderOutput("Your robot can turn (L)eft, turn (R)ight, and (M)ove forward");
			string preProgrammedMoves = RobotDataCollection.ValidatePreProgrammedMoves(renderer.ReadInput,
													"Please enter the robots pre-programmed moves as a collection of L M R:",
													"Your robot doesn't have any valid moves - valid inputs are L, M and R");

			IRobot robot = new Robot(renderer, positionOnArena, robotOrientation, preProgrammedMoves);

			try
			{
				game.AddRobotToGame(robot);
			}
			catch (ArgumentOutOfRangeException)
			{
				renderer.RenderError("You have attempted to put the robot outside of the arena - unable to add the robot");
			}
		}
	}
}
