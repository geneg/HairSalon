using com.geneg.hairsalon.Common;
using com.geneg.hairsalon.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.geneg.hairsalon.ToolPanelFeature
{
	public class ToolPanelFeature : BaseFeature, IFeature
	{
		ToolPanelView _view;
		
		public ToolPanelFeature(Transform root) : base(root) { }
		
		public override void SetView(BaseView view)
		{
			_view = (ToolPanelView) view; //the feature is in the same context with the view so we can cast it
		}
		
		public override void StartFeature()
		{
			foreach (ToolButton toolButton in _view.ToolButtons)
			{
				toolButton.OnMouseDownEvent += OnToolMouseDown;
				toolButton.OnMouseUpEvent += OnToolMouseUp;
			}
		}
		
		private void OnToolMouseUp(string toolName)
		{
			GlobalEventBus.Publish(new ToolPanelEvent(ToolPanelEvent.ToolDeselected, toolName));
		}

		private void OnToolMouseDown(string toolName)
		{
			GlobalEventBus.Publish(new ToolPanelEvent(ToolPanelEvent.ToolSelected, toolName));
		}

		public override void OnDestroy()
		{
			foreach (ToolButton toolButton in _view.ToolButtons)
			{
				toolButton.OnMouseDownEvent -= OnToolMouseDown;
				toolButton.OnMouseUpEvent -= OnToolMouseUp;
			}
		}
		
	}
}
