using UnityEngine;

public partial class EasingFunctions
{
	// public const string _easeModes = "EaseInCubic, EaseOutCubic, EaseInOutCubic";
	// public static string EaseModes() => _easeModes;
	public static float EaseInCubic(float x)
	{
		return x * x * x;
	}
	public  static float EaseOutCubic(float x)
	{
		return 1 - Mathf.Pow(1 - x, 3); ;
	}
	public static float EaseInOutCubic(float x)
	{
		return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
	}
	
	public static float EaseMode(int easeMode, float time)
	{
		switch (easeMode)
		{
			case 0:
				return EaseInCubic(time);
			case 1:
				return EaseOutCubic(time);
			case 3:
				return EaseInOutCubic(time);
			default:
				return time;

		}
	}
}
