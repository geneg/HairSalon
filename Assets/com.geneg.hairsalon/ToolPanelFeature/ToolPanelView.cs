using System.Collections.Generic;
using com.geneg.hairsalon.Common;
using UnityEngine;

namespace com.geneg.hairsalon.ToolPanelFeature
{
	public class ToolPanelView : BaseView
	{
		[SerializeField] List<ToolButton> _toolButtons;
		public List<ToolButton> ToolButtons => _toolButtons;

		
	}
}
