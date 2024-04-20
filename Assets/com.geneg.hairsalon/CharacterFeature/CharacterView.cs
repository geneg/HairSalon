using System.Collections.Generic;
using com.geneg.hairsalon.Common;
using UnityEngine;

namespace com.geneg.hairsalon.CharacterFeature
{
	public class CharacterView : BaseView
	{
		public List<Color> HairColors => _hairColors;
		[SerializeField] private List<Color> _hairColors;
		
		public List<Hair> Hairs => hairs;
		[SerializeField] List<Hair> hairs; //replace it with some logic that instantiates hairs dynamically on some given area
	}
}
