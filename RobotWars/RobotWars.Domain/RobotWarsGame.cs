using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Domain.Contracts;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain
{
	public class RobotWarsGame
	{
		private readonly IOutputRenderer renderer;
		private readonly GameArena arena;
		private readonly Lazy<List<IRobot>> robots = new Lazy<List<IRobot>>();
 
		public RobotWarsGame(IOutputRenderer renderer, GameArena arena)
		{
			this.renderer	= renderer;
			this.arena		= arena;
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot is outside of the arena</exception>
		public void AddRobotToGame(IRobot robot)
		{
			robot.SetArenaSize(arena.GetArenaBottomLeft(), arena.GetArenaTopRight());
			robots.Value.Add(robot);
		}

		public void PlayGame()
		{
			while (RobotsHaveMovesRemaining())
			{
				// at the moment, we shan't do anything in parallel in terms of letting the robots take
				// out their turns in sequence, we just want to ensure that the output is as expected
				foreach (var robot in robots.Value)
				{
					try
					{
						robot.PerformNextMove();
					}
					catch (ArgumentOutOfRangeException)
					{
						renderer.RenderError("Attempt to move to a location outside of the arena - move has been skipped");
					}
				}
			}
		}

		private bool RobotsHaveMovesRemaining()
		{
			return robots.Value.Any(robot => robot.HasMovesRemaining());
		}

		public void GetFinalPositions()
		{
			foreach (var robot in robots.Value)
			{
				renderer.RenderOutput(robot.ToString());
			}
		}
	}
}