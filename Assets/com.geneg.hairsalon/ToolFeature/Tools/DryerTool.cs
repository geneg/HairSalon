
using System;
using com.geneg.hairsalon.CharacterFeature;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace com.geneg.hairsalon.ToolFeature.Tools
{
	public class DryerTool : BaseTool
	{
		[SerializeField] private float _centerOffset = 1f;
			
		private bool _isFirstTimeAngleCalculation;
		private float _initialAngle;
		private Vector2 _spritePivot;
		
		public override void Init()
		{
			_isFirstTimeAngleCalculation = true;
			_spritePivot = _spriteRenderer.sprite.pivot.normalized;
			
			base.Init();
		}
		
		public override void Apply(Hair effectedObject)
		{
			if (_spriteRenderer.flipX)
			{
				effectedObject.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 240);
			}
			else
			{
				effectedObject.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -240);
			}
		}

		protected override void Update()
		{
			base.Update();
			
			Vector3 mousePosition;
			Vector3 direction;
			
			if (_spriteRenderer.flipX)
			{
				mousePosition = Input.mousePosition + new Vector3(-_centerOffset, 0, 0);;
			}
			else
			{
				mousePosition = Input.mousePosition + new Vector3(_centerOffset, 0, 0);;
			}
			
			mousePosition.z = 10; // Set this to the distance between the camera and the objects it is rendering
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
			
			//position of the tool is update to match the mouse position, taking into account the pivot of the sprite
			if (_spriteRenderer.flipX)
			{
				transform.position = worldPosition + new Vector3(_spritePivot.x, _spritePivot.y, 0) + new Vector3(-_centerOffset, 0, 0);
				direction =  new Vector3(-_centerOffset,1.1f,0) - transform.position;
			}
			else
			{
				transform.position = worldPosition + new Vector3(_spritePivot.x, _spritePivot.y, 0) + new Vector3(_centerOffset, 0, 0);
				direction =  new Vector3(_centerOffset,1.1f,0) - transform.position;
			}
			
			float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
			
			//if this is the first time the angle is being calculated. If it is, the initial angle is saved for future calculations
			if (_isFirstTimeAngleCalculation)
			{
				_initialAngle = angle;
				_isFirstTimeAngleCalculation = false;
			}

			//ensures that the tool always faces the correct direction based on the mouse position.
			if(angle < 90 && angle > -90)
			{
				_spriteRenderer.flipX = false;
				transform.rotation = UnityEngine.Quaternion.AngleAxis(_initialAngle - angle, Vector3.forward);
			}
			else
			{
				_spriteRenderer.flipX = true;
				transform.rotation = UnityEngine.Quaternion.AngleAxis(180 - _initialAngle - angle, Vector3.forward);
			}
			
		}
	}
}
