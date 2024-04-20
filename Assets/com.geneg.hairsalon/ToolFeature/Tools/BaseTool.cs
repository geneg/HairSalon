using System;
using com.geneg.hairsalon.CharacterFeature;
using com.geneg.hairsalon.Common;
using UnityEngine;


namespace com.geneg.hairsalon.ToolFeature.Tools
{
	public abstract class BaseTool : MonoBehaviour, ITool
	{
		[SerializeField] protected SpriteRenderer _spriteRenderer;
		private bool _initialized;

		public string Name { get; set; }
		
		public virtual void Init()
		{
			_spriteRenderer.sortingLayerName = "tools";
			_spriteRenderer.color = Utils.ChangeAlpha(_spriteRenderer.color, 1f);
			_initialized = true;
		}

		public abstract void Apply(Hair effectedObject);

		protected virtual void Update()
		{
			//prevent the tool from being updated if it has not been initialized
			if (!_initialized) return;
			
			
			
		}
	}
}
