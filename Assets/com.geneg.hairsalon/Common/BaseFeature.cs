using UnityEngine;

namespace com.geneg.hairsalon.Common
{
	public abstract class BaseFeature : IFeature
	{
		private EventBus _globalEventBus;
		public EventBus GlobalEventBus => _globalEventBus;

		void IFeature.SetGlobalEventBus(EventBus eventBus)
		{
			_globalEventBus = eventBus;
		}

		protected BaseFeature(Transform root) { }
		public abstract void SetView(BaseView view);
		public abstract void StartFeature();
		public abstract void OnDestroy();

		
	}
}
