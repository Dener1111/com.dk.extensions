using UnityEngine;

public static partial class StringExtensions
{
	/// <summary>Deletes substring from string</summary>
	/// <param name="removeString">To delete</param>
	public static string Remove(this string value, string removeString)
	{
		var index = value.IndexOf(removeString);
		var cleanPath = (index < 0) ?
			value :
			value.Remove(index, removeString.Length);

		return cleanPath;
	}

	/// <summary>Upercase first letter of every word</summary>
	public static string UppercaseWords(this string value)
	{
		var array = value.ToCharArray();

		// Handle the first letter in the string
		if (array.Length >= 1)
		{
			if (char.IsLower(array[0]))
				array[0] = char.ToUpper(array[0]);
		}

		// Scan through the letters, checking for spaces
		// Uppercase the lowercase letters following spaces
		for (var i = 1; i < array.Length; i++)
		{
			if (array[i - 1] == ' ')
			{
				if (char.IsLower(array[i]))
					array[i] = char.ToUpper(array[i]);
			}
		}
		
		return new string(array);
	}
	
	/// <summary>Returns true if string is null or empty</summary>
	public static bool IsNullOrEmpty(this string value)
	{
		return string.IsNullOrEmpty(value);
	}

	/// <summary>Returns Animator Hash for string</summary>
	public static int AnimatorHash(this string value) => Animator.StringToHash(value);
}
