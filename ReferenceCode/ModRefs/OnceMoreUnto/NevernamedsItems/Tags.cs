using System.Collections.Generic;
using Alexandria.ItemAPI;

namespace NevernamedsItems;

public class Tags
{
	public static void Init()
	{
		AddTags(new List<int> { 105, 272 }, "lucky");
		AddTags(new List<int> { 289 }, "very_lucky");
	}

	public static void AddTags(List<int> items, string tag)
	{
		foreach (int item in items)
		{
			AlexandriaTags.SetTag(item, tag);
		}
	}
}
