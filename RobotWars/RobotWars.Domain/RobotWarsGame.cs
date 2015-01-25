﻿using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Domain.Contracts;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain
{
	public class RobotWarsGame
	{
		private readonly IOutputRenderer _renderer;
		private readonly GameArena _arena;
		private readonly Lazy<List<IRobot>> _robots = new Lazy<List<IRobot>>();
 
		public RobotWarsGame(IOutputRenderer renderer, GameArena arena)
		{
			_renderer	= renderer;
			_arena		= arena;
		}

		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot is outside of the arena</exception>
		public void AddRobotToGame(IRobot robot)
		{
			robot.SetArenaSize(_arena.GetArenaBottomLeft(), _arena.GetArenaTopRight());
			_robots.Value.Add(robot);
		}

		public void PlayGame()
		{
			while (RobotsHaveMovesRemaining())
			{
				// at the moment, we shan't do anything in parallel in terms of letting the robots take
				// out their turns in sequence, we just want to ensure that the output is as expected
				foreach (var _robot in _robots.Value)
				{
					try
					{
						_robot.PerformNextMove();
					}
					catch (ArgumentOutOfRangeException)
					{
						_renderer.RenderError("Attempt to move to a location outside of the arena - move has been skipped");
					}
				}
			}
		}

		private bool RobotsHaveMovesRemaining()
		{
			return _robots.Value.Any(robot => robot.HasMovesRemaining());
		}

		public void GetFinalPositions()
		{
			foreach (var _robot in _robots.Value)
			{
				_renderer.RenderOutput(_robot.ToString());
			}
		}
	}
}