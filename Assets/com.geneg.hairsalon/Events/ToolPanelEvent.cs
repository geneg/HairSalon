
namespace com.geneg.hairsalon.Events
{
	public class ToolPanelEvent
	{
		public const string ToolSelected = "ToolSelected";
		public const string ToolDeselected = "ToolDeselected";
		
		public string EventType { get; private set; }
		public string Data { get; private set; }
		
		public ToolPanelEvent(string eventType, string data)
		{
			EventType = eventType;
			Data = data;
		}

	}
}
