using com.geneg.hairsalon.Common;
using UnityEngine;

namespace com.geneg.hairsalon.ToolFeature
{
	public class ToolFeatureView : BaseView
	{
		[SerializeField] private ToolData _toolData;
		public ToolData ToolData => _toolData;
	}
}
