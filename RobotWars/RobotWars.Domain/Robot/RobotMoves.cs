using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RobotWars.Domain.Robot
{
	public class RobotMoves
	{
		private readonly Queue<char> _preProgrammedMoves;

		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public RobotMoves(string preProgrammedMoves)
		{
			if (preProgrammedMoves == null || !TryParseMoves(preProgrammedMoves, out preProgrammedMoves))
			{
				throw new ArgumentOutOfRangeException("preProgrammedMoves", "Invalid moves specificed for the robot");				
			}

			_preProgrammedMoves = new Queue<char>(preProgrammedMoves.ToList());
		}

		public char? GetNextMove()
		{
			if (_preProgrammedMoves.Count > 0)
				return _preProgrammedMoves.Dequeue();

			return null;
		}

		public static bool TryParseMoves(string userInput, out string moves)
		{
			moves = Regex.Replace(userInput, @"[^LMR]", "", RegexOptions.IgnoreCase);

			return !string.IsNullOrEmpty(moves);
		}

		public override string ToString()
		{
			return new string(_preProgrammedMoves.ToArray());
		}

		public bool HasMovedRemaining()
		{
			return _preProgrammedMoves.Count > 0;
		}
	}
}