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

		public void RenderOutput(string output)
		{
			Console.WriteLine(output);
		}

		public void RenderDebug(string output)
		{
			if (_renderDebugOutput)
				Console.WriteLine(output);
		}

		public string ReadInput()
		{
			return Console.ReadLine();
		}
	}
}