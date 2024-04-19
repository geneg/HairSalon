using System.Collections.Generic;
using com.geneg.hairsalon.ToolPanelFeature;
using UnityEngine;

namespace com.geneg.hairsalon.Common
{
	public class FeatureResolver
	{
		private readonly Dictionary<FeatureType,IFeature> _features = new Dictionary<FeatureType, IFeature>();
		private EventBus _globalEventBus = new EventBus();

		public void AddFeature(FeatureType key, IFeature feature, BaseView view)
		{
			feature.SetView(view);
			AddFeature(key, feature);
		}

		//for features without view
		public void AddFeature(FeatureType key, IFeature feature)
		{
			feature.SetGlobalEventBus(_globalEventBus);
			_features[key] = feature;
		}
		
		public IFeature GetFeature(FeatureType key)
		{
			if (_features.TryGetValue(key, out IFeature feature))
			{
				return feature;
			}
			
			//TODO: Add shadow logger service in different thread that catches all logs with ErrorType key and sends them to the server. 
			Debug.Log($"{ErrorType.CriticalError}: Feature with key {key} not found.");

			return null;
		}
		
		public void Inject(EventBus eventBus)
		{
			_globalEventBus = eventBus;
		}
	}
}
