using UnityEngine;

namespace com.geneg.hairsalon.ToolFeature
{
	public interface ITool
	{
		// Define the methods and properties that a tool should have
		string Name { get; set; }
		void Init();
		void Apply(GameObject effectedObject);
	}
}
