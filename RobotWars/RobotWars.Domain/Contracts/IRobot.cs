using System;
using System.Drawing;

namespace RobotWars.Domain.Contracts
{
	// it would have been rude not to? :)
	public interface IRobot
	{
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the robot is outside of the arena</exception>
		void SetArenaSize(Point arenaBottomLeft, Point arenaTopRight);

		void PerformNextMove();
		bool HasMovesRemaining();
	}
}
