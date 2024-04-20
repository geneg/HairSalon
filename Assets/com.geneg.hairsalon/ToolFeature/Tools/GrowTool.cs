
using System;
using com.geneg.hairsalon.CharacterFeature;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace com.geneg.hairsalon.ToolFeature.Tools
{
	//this class is responsible for cutting the hair
	//it is not perfect, but it is a good start
	
	public class GrowTool : BaseTool
	{
		
		public override void Apply(Hair effectedObject)
		{
				
				effectedObject.transform.localScale = new Vector3(effectedObject.transform.localScale.x, 1f, effectedObject.transform.localScale.z);
				
		}

		protected override void Update()
		{
			base.Update();
			
			Vector3 mousePosition;
			mousePosition = Input.mousePosition;
		
			mousePosition.z = 10; // Set this to the distance between the camera and the objects it is rendering
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
			
			transform.position = worldPosition;
			
		}
	}
}
