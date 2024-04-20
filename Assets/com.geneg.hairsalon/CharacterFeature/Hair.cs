using System;
using com.geneg.hairsalon.Common;
using com.geneg.hairsalon.ToolFeature;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.geneg.hairsalon.CharacterFeature
{
	public class Hair : BaseView
	{
		[SerializeField] SpriteRenderer _spriteRenderer;
		
		private bool _isUpdateEnabled = false;
		private bool _isTriggered = false;
		
		public ITool Tool { get; set; }

		private void OnTriggerEnter2D(Collider2D other)
		{
			_isTriggered = true;
			
			//TODO: run some flipping animation on the hair object
		}
		
		private void OnTriggerExit2D(Collider2D other)
		{
			_isTriggered = false;
			
			//TODO: stop run flipping animation 
		}

		private void Update()
		{
			if (!_isUpdateEnabled || !_isTriggered) return;
			
			this.Tool?.Apply(this.gameObject);
		}

		public void SetUpdateEnabled()
		{
			_isUpdateEnabled = true;
		}
		
		public void SetUpdateDisabled()
		{
			_isUpdateEnabled = false;
		}
		
		public void SetColor(Color hairColor)
		{
			_spriteRenderer.color = hairColor;
		}
		public void RandomizeWidth()
		{
			var localScale = this.transform.localScale;
			localScale = new Vector3(localScale.x, Random.Range(0.7f, 1.2f), localScale.z);
			this.transform.localScale = localScale;
		}
		
		public void RandomizeFlip()
		{
			_spriteRenderer.flipY = Random.Range(0, 2) == 0;
		}
	}
}
