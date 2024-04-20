using com.geneg.hairsalon.Common;
using com.geneg.hairsalon.Events;
using UnityEngine;

namespace com.geneg.hairsalon.CharacterFeature
{
	public class CharacterFeature : BaseFeature
	{
		private CharacterView _view;

		public CharacterFeature(Transform root) : base(root) { }
		
		public override void SetView(BaseView view)
		{
			_view = (CharacterView) view;
		}
		
		public override void StartFeature()
		{
			GlobalEventBus.Subscribe<ToolEvent>(OnToolEvent);
			
			foreach (Hair hair in _view.Hairs)
			{
				hair.RandomizeWidth();
				hair.RandomizeFlip();
				hair.SetColor(_view.HairColors[Random.Range(0, _view.HairColors.Count)]);
				hair.SetUpdateDisabled();
			}
		}
		
		private void OnToolEvent(ToolEvent e)
		{
			switch (e.ActionType)
			{
				case ToolEvent.ToolCreated:
					//hairs list enable update
					foreach (Hair hair in _view.Hairs)
					{
						hair.Tool = e.Tool;
						hair.SetUpdateEnabled();
					}
					break;
				
				case ToolEvent.ToolDestroyed:
					//hairs list disable update
					foreach (Hair hair in _view.Hairs)
					{
						hair.SetUpdateDisabled();
						hair.Tool = null;
					}
					break;
			}
		}

		public override void OnDestroy()
		{
			GlobalEventBus.Unsubscribe<ToolEvent>(OnToolEvent);
		}
	}
}
