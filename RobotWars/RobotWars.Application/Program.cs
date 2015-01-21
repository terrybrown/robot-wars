using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotWars.Domain;

namespace RobotWars.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = new RobotWarsGame(new GameArena(5, 5));

			game.AddRobotToGame(positionX: 1, positionY: 2, heading: 'N', moves: "LMLMLMLMM");
		}
	}
}
