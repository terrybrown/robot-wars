using System;
using System.Collections.Generic;

namespace RobotWars.Domain
{
	public class RobotWarsGame
	{
		private GameArena arena;
		private readonly Lazy<List<Robot>> _robots = new Lazy<List<Robot>>();
 
		public RobotWarsGame(GameArena arena)
		{
			this.arena = arena;
		}

		public void AddRobotToGame(int positionX, int positionY, Orientation orientation, string moves)
		{
			_robots.Value.Add(new Robot(positionX, positionY, orientation, moves, arena.GetArenaSize()));
		}

		public void PlayGame()
		{
			// at the moment, we shan't do anything in parallel in terms of letting the robots take
			// out their turns in sequence, we just want to ensure that the output is as expected
			foreach (var robot in _robots.Value)
			{
				robot.PerformProgrammedMoves();

				Console.WriteLine("----------------------------------------------------");
			}

			Console.ReadKey();
		}
	}
}