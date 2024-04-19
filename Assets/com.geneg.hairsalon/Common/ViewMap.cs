using System.Collections.Generic;
using UnityEngine;

namespace com.geneg.hairsalon.Common
{
	public class ViewMap : MonoBehaviour
	{
		[Header("Bind views to features")]
		[SerializeField]
		private List<FeatureType> _featureType;
		[SerializeField]
		private List<BaseView> _views;
		
		public T GetView<T>(FeatureType featureType) where T : BaseView
		{
			//find index of viewType in _viewTypes
			int index = _featureType.FindIndex(x => x == featureType);

			if (index != -1)
			{
				return _views[index] as T;
			}

			return null;
		}
		
		//returns view base type
		public BaseView GetView(FeatureType featureType)
		{
			//find index of viewType in _viewTypes
			int index = _featureType.FindIndex(x => x == featureType);
			return index != -1 ? _views[index] : null;

		}
	}
}
