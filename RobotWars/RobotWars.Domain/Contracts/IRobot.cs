using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Domain.Contracts
{
	// it would have been rude not to? :)
	public interface IRobot
	{
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot is outside of the arena</exception>
		void SetArenaSize(Point arenaBottomLeft, Point arenaTopRight);

		void PerformProgrammedMoves();
	}
}
