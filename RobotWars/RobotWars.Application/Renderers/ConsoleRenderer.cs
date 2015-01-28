using System;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Application.Renderers
{
	public class ConsoleRenderer : IOutputRenderer, IInputRenderer
	{
		private readonly bool renderDebugOutput;

		public ConsoleRenderer(bool renderDebugOutput)
		{
			this.renderDebugOutput = renderDebugOutput;
		}

		public void RenderOutput(string output, params object[] args)
		{
			Console.WriteLine(output, args);
		}

		public void RenderError(string output, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(output, args);
			Console.ResetColor();
		}

		public void RenderDebug(string output, params object[] args)
		{
			if (renderDebugOutput)
				Console.WriteLine(output, args);
		}

		public string ReadInput()
		{
			return Console.ReadLine();
		}
	}
}