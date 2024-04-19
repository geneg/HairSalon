using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.geneg.hairsalon.ToolFeature
{
    public class ToolFactory
    {
        private readonly ToolData _toolData;
        private readonly Transform _root;
        private readonly List<ITool> _tools;

        public ToolFactory(ToolData toolData, Transform root)
        {
            _toolData = toolData;
            _root = root;
            _tools = new List<ITool>();
        }

        public ITool CreateTool(string toolName)
        {
            GameObject toolPrefab = _toolData.GetPrefab(toolName);
            GameObject toolObject = Object.Instantiate(toolPrefab, _root);
            ITool tool = toolObject.GetComponent<ITool>();
            
            tool.Name = toolName;
            _tools.Add(tool);
            
            return tool;
        }

        public void DestroyTool(string toolName)
        {
            ITool tool = _tools.FirstOrDefault(t => t.Name == toolName);
            
            if (tool == null) return;
            
            _tools.Remove(tool);
            Object.Destroy(((Component)tool).gameObject);
        }
    }
}