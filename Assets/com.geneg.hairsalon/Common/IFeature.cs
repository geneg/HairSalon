namespace com.geneg.hairsalon.Common
{
	public interface IFeature
	{
		void SetView(BaseView view);
		void StartFeature();
		void OnDestroy();
		EventBus GlobalEventBus { get; }
		void SetGlobalEventBus(EventBus eventBus); 
	}
}
