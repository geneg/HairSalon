using com.geneg.hairsalon.Common;
using com.geneg.hairsalon.Events;
using UnityEngine;

namespace com.geneg.hairsalon.ToolFeature
{
	/*
	 * ToolFeature is a feature that is responsible for managing the tools on the game play area.
	 */
	
	public class ToolFeature : BaseFeature
	{
		private ToolFeatureView _view;
		private ToolFactory _toolFactory;
		private readonly Transform _root;

		public ToolFeature(Transform root) : base(root)
		{
			_root = root;
		}

		public override void SetView(BaseView view)
		{
			_view = (ToolFeatureView) view;
		}
		
		public override void StartFeature()
		{
			GlobalEventBus.Subscribe<ToolPanelEvent>(OnToolPanelEvent);

			_toolFactory = new ToolFactory(_view.ToolData, _view.transform);
		}
		
		private void OnToolPanelEvent(ToolPanelEvent e)
		{
			switch (e.EventType)
			{
				case ToolPanelEvent.ToolSelected:
					//create a new tool
					_toolFactory.CreateTool(e.Data); 
					break;
				
				case ToolPanelEvent.ToolDeselected: 
					//destroy the tool
					//think about the tool pool!!!
					//for now it is only 3 tools so just destroy it
					
					_toolFactory.DestroyTool(e.Data);
					break;
			}

		}

		public override void OnDestroy()
		{
			
		}
		
	}
}
