using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Application.Properties;
using RobotWars.Application.Renderers;
using RobotWars.Domain;
using RobotWars.Domain.InputOutput;
using RobotWars.Domain.Robot;
using RobotWars.Domain.Validation;

namespace RobotWars.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleRenderer _renderer = new ConsoleRenderer(Settings.Default.RenderDebugOutput);

			_renderer.RenderOutput("Robot Wars ---------------------------------------");
			_renderer.RenderOutput("Verbose output is set to '{0}' - you can change it in app.config", Settings.Default.RenderDebugOutput);
			_renderer.RenderOutput("");

			int _arenaWidth	= GameDataCollection.ValidateArenaDimension(_renderer.ReadInput, 
																	"Please enter the arena width", 
																	"That's not a valid width - please enter a number between 1 and 100");
			int _arenaHeigth = GameDataCollection.ValidateArenaDimension(_renderer.ReadInput, 
																	"Please enter the arena height", 
																	"That's not a valid height - please enter a number between 1 and 100");

			var _game = new RobotWarsGame(_renderer, new GameArena(_arenaWidth, _arenaHeigth));

			_renderer.RenderOutput("Robot Factory ---------------------------------------");
			bool _addAnotherRobot = true;
			while (_addAnotherRobot)
			{
				// collect first robot details here
				CollectAndBuildRobot(_renderer, _game);

				_renderer.RenderOutput("");
				_renderer.RenderOutput("Add another robot?");
				_addAnotherRobot = GeneralDataCollection.DoesInputMatchSuccessValue(_renderer.ReadInput, "Y");
			}

			_game.PlayGame();


			Console.ForegroundColor = ConsoleColor.Cyan;
			_renderer.RenderOutput("Final Positions ------------------------------------------------");
			
			_game.GetFinalPositions();

			Console.ReadKey();
		}

		private static void CollectAndBuildRobot(ConsoleRenderer renderer, RobotWarsGame game)
		{

			Point _positionOnArena = RobotDataCollection.CollectPosition(renderer.ReadInput, 
													"Please enter the robot's position on the arena in X,Y format:",
													"That's not a valid position - please enter in the format X,Y"
													);



			Orientation _robotOrientation = RobotDataCollection.ValidateOrientation(renderer.ReadInput,
													"Please enter the robots orientation as a compass point (N, E, S, W):",
													"That is not a valid compass point");


			renderer.RenderOutput("Your robot can turn (L)eft, turn (R)ight, and (M)ove forward");
			string _preProgrammedMoves = RobotDataCollection.ValidatePreProgrammedMoves(renderer.ReadInput,
													"Please enter the robots pre-programmed moves as a collection of L M R:",
													"Your robot doesn't have any valid moves - valid inputs are L, M and R");

			Robot _robot = new Robot(renderer, _positionOnArena, _robotOrientation, _preProgrammedMoves);

			try
			{
				game.AddRobotToGame(_robot);
			}
			catch (ArgumentOutOfRangeException)
			{
				renderer.RenderError("You have attempted to put the robot outside of the arena - unable to add the robot");
			}
		}
	}
}
