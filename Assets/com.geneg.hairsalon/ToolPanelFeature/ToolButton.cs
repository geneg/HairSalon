using System;
using com.geneg.hairsalon.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.geneg.hairsalon.ToolPanelFeature
{
	public class ToolButton : MonoBehaviour
	{
		[SerializeField] private string _toolName;
		[SerializeField] SpriteRenderer _spriteRenderer;
		
		public event Action<string> OnMouseDownEvent;
		public event Action<string> OnMouseUpEvent;
		
		private void OnMouseDown()
		{
			_spriteRenderer.color = Utils.ChangeAlpha(_spriteRenderer.color, 0f);
			OnMouseDownEvent?.Invoke(_toolName);
		}
		
		private void OnMouseUp()
		{
			_spriteRenderer.color = Utils.ChangeAlpha(_spriteRenderer.color, 1f);
			OnMouseUpEvent?.Invoke(_toolName);
		}
		
	}
}
