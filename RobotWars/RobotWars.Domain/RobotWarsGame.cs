using System.Collections.Generic;

namespace RobotWars.Domain
{
	public class RobotWarsGame
	{
		private GameArena arena;
		private List<Robot> robots;
 
		public RobotWarsGame(GameArena arena)
		{
			this.arena = arena;
		}

		public void AddRobotToGame(int positionX, int positionY, char heading, string moves)
		{
			robots.Add(new Robot(positionX, positionY, heading, moves, arena.GetArenaSize()));
		}
	}
}