using com.geneg.hairsalon.ToolFeature;

namespace com.geneg.hairsalon.Events
{
	public class ToolEvent
	{
		public const string ToolCreated = "ToolCreated";
		public const string ToolDestroyed = "ToolDestroyed";
		
		public ITool Tool => _tool;
		public string ActionType => _actionType;
		
		private readonly ITool _tool;
		private readonly string _actionType;
		
		public ToolEvent(string actionType, ITool tool)
		{
			_tool = tool;
			_actionType = actionType;
		}
		
		public ToolEvent(string actionType, string toolName)
		{
			_actionType = actionType;
		}

		
	}
}
