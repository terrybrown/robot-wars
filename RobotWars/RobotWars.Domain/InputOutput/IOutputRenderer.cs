namespace RobotWars.Domain.InputOutput
{
	public interface IOutputRenderer
	{
		void RenderOutput(string output);
		void RenderOutput(string output, params object[] args);
		void RenderDebug(string output);
	}
}