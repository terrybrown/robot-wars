using System;
using RobotWars.Domain.InputOutput;

namespace RobotWars.Application.Renderers
{
	public class ConsoleRenderer : IOutputRenderer, IInputRenderer
	{
		private readonly bool _renderDebugOutput;

		public ConsoleRenderer(bool renderDebugOutput)
		{
			_renderDebugOutput = renderDebugOutput;
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
			if (_renderDebugOutput)
				Console.WriteLine(output, args);
		}

		public string ReadInput()
		{
			return Console.ReadLine();
		}
	}
}