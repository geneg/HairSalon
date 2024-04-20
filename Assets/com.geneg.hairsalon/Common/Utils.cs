using UnityEngine;

namespace com.geneg.hairsalon.Common
{
	public static class Utils
	{
		public static Color ChangeAlpha(Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}
	}
}
