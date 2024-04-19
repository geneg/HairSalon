namespace com.geneg.hairsalon.ToolFeature
{
	using UnityEngine;
	using System.Collections.Generic;

	[CreateAssetMenu(fileName = "ToolData", menuName = "ScriptableObjects/ToolData", order = 1)]
	public class ToolData : ScriptableObject
	{
		[System.Serializable]
		public class ToolPrefab
		{
			public string toolName;
			public GameObject prefab;
		}

		public List<ToolPrefab> toolPrefabs;

		public GameObject GetPrefab(string toolName)
		{
			foreach (ToolPrefab toolPrefab in toolPrefabs)
			{
				if (toolPrefab.toolName == toolName)
				{
					return toolPrefab.prefab;
				}
			}

			return null;
		}
	}
}
