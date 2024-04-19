using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.geneg.hairsalon.ToolPanelFeature
{
	public class ToolButton : MonoBehaviour
	{
		[SerializeField] private string _toolName;
		
		public event Action<string> OnMouseDownEvent;
		public event Action<string> OnMouseUpEvent;
		
		private void OnMouseDown()
		{
			OnMouseDownEvent?.Invoke(_toolName);
		}
		
		private void OnMouseUp()
		{
			OnMouseUpEvent?.Invoke(_toolName);
		}
		
	}
}
