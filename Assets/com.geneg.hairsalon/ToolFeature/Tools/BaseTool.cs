using System;
using com.geneg.hairsalon.Common;
using UnityEngine;


namespace com.geneg.hairsalon.ToolFeature.Tools
{
	public abstract class BaseTool : MonoBehaviour, ITool
	{
		[SerializeField] protected SpriteRenderer _spriteRenderer;
		
		private bool _isFirstTimeAngleCalculation;
		private float _initialAngle;
		private Vector2 _spritePivot;

		public string Name { get; set; }
		public void Init()
		{
			_isFirstTimeAngleCalculation = true;
			_spriteRenderer.sortingLayerName = "tools";
			_spriteRenderer.color = Utils.ChangeAlpha(_spriteRenderer.color, 1f);
			_spritePivot = _spriteRenderer.sprite.pivot.normalized;
		}

		private void Update()
		{
			Vector3 mousePosition;
			
			if (_spriteRenderer.flipX)
			{
				mousePosition = Input.mousePosition + new Vector3(-1, 0, 0);;
			}
			else
			{
				mousePosition = Input.mousePosition + new Vector3(1, 0, 0);;
			}
			
			mousePosition.z = 10; // Set this to the distance between the camera and the objects it is rendering
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

			if (_spriteRenderer.flipX)
			{
				transform.position = worldPosition + new Vector3(_spritePivot.x, _spritePivot.y, 0) - new Vector3(1, 0, 0);
			}
			else
			{
				transform.position = worldPosition + new Vector3(_spritePivot.x, _spritePivot.y, 0);	
			}
			
			
			// Update the rotation of the tool to match the mouse position
			// Calculate the direction vector from the tool's position to the target position
			Vector3 direction;
				
			if (_spriteRenderer.flipX)
				direction =  new Vector3(-1,1.1f,0) - transform.position;
			else
			    direction =  new Vector3(1,1.1f,0) - transform.position;

			// Calculate the rotation angle from the direction vector
			float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
			
			if (_isFirstTimeAngleCalculation)
			{
				// Save the initial angle
				_initialAngle = angle;
				_isFirstTimeAngleCalculation = false;
			}

			if(angle < 90 && angle > -90)
			{
				_spriteRenderer.flipX = false;
				
				
				transform.rotation = Quaternion.AngleAxis(_initialAngle - angle, Vector3.forward);
			}
			else
			{
				_spriteRenderer.flipX = true;
				
				transform.rotation = Quaternion.AngleAxis((180 - _initialAngle) - angle, Vector3.forward);
			}
			
			// Apply the rotation to the tool
			
		}
	}
}
