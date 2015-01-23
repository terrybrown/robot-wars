using RobotWars.Domain.InputOutput;

namespace RobotWars.Domain.Tests.Unit
{
	public class NullRenderer : IInputRenderer, IOutputRenderer
	{
		public string ReadInput()
		{
			return string.Empty;
		}

		public void RenderOutput(string output)
		{
		}

		public void RenderOutput(string output, params object[] args)
		{
		}

		public void RenderDebug(string output)
		{
		}
	}
}