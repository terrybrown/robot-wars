using System;
using System.Collections.Generic;
using System.IO;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain
{
	public class RobotWarsGame
	{
		private readonly IOutputRenderer _renderer;
		private readonly GameArena _arena;
		private readonly Lazy<List<Robot.Robot>> _robots = new Lazy<List<Robot.Robot>>();
 
		public RobotWarsGame(IOutputRenderer renderer, GameArena arena)
		{
			_renderer = renderer;
			this._arena = arena;
		}

		public void AddRobotToGame(Robot.Robot robot)
		{
			robot.SetArenaSize(_arena.GetArenaSize());
			_robots.Value.Add(robot);
		}

		public void PlayGame()
		{
			// at the moment, we shan't do anything in parallel in terms of letting the robots take
			// out their turns in sequence, we just want to ensure that the output is as expected
			foreach (var robot in _robots.Value)
			{
				robot.PerformProgrammedMoves();

				_renderer.RenderOutput("----------------------------------------------------");
			}
		}

		public void GetFinalPositions()
		{
			foreach (var robot in _robots.Value)
			{
				_renderer.RenderOutput(robot.ToString());
			}
		}
	}
}