using UnityEngine;

namespace GungeonAPI;

public static class TextureStitcher
{
	public static readonly int padding = 1;

	public static Rect AddFaceCardToAtlas(Texture2D tex, Texture2D atlas, int index, Rect bounds)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)(((Rect)(ref bounds)).width / 34f);
		int num2 = (int)(((Rect)(ref bounds)).height / 34f);
		int num3 = index % num;
		int num4 = index / num;
		if (num3 >= num || num4 >= num2)
		{
			Tools.PrintError("Not enough room left on the Facecard Atlas for this facecard!");
			return Rect.zero;
		}
		int num5 = (int)((Rect)(ref bounds)).x + num3 * 34;
		int num6 = (int)((Rect)(ref bounds)).y + num4 * 34;
		for (int i = 0; i < ((Texture)tex).width; i++)
		{
			for (int j = 0; j < ((Texture)tex).height; j++)
			{
				atlas.SetPixel(i + num5, j + num6, tex.GetPixel(i, j));
			}
		}
		atlas.Apply(false, false);
		return new Rect((float)num5 / (float)((Texture)atlas).width, (float)num6 / (float)((Texture)atlas).height, 34f / (float)((Texture)atlas).width, 34f / (float)((Texture)atlas).height);
	}

	public static Rect ReplaceFaceCardInAtlas(Texture2D tex, Texture2D atlas, Rect region)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)Mathf.Round((float)((Texture)atlas).width * ((Rect)(ref region)).x);
		int num2 = (int)Mathf.Round((float)((Texture)atlas).width * ((Rect)(ref region)).y);
		for (int i = 0; i < ((Texture)tex).width; i++)
		{
			for (int j = 0; j < ((Texture)tex).height; j++)
			{
				atlas.SetPixel(i + num, j + num2, tex.GetPixel(i, j));
			}
		}
		atlas.Apply(false, false);
		return new Rect((float)num / (float)((Texture)atlas).width, (float)num2 / (float)((Texture)atlas).height, 34f / (float)((Texture)atlas).width, 34f / (float)((Texture)atlas).height);
	}

	public static Texture2D CropWhiteSpace(this Texture2D orig)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Rect trimmedBounds = orig.GetTrimmedBounds();
		Texture2D val = new Texture2D((int)((Rect)(ref trimmedBounds)).width, (int)((Rect)(ref trimmedBounds)).height);
		((Object)val).name = ((Object)orig).name;
		for (int i = (int)((Rect)(ref trimmedBounds)).x; (float)i < ((Rect)(ref trimmedBounds)).x + ((Rect)(ref trimmedBounds)).width; i++)
		{
			for (int j = (int)((Rect)(ref trimmedBounds)).y; (float)j < ((Rect)(ref trimmedBounds)).y + ((Rect)(ref trimmedBounds)).height; j++)
			{
				val.SetPixel(i - (int)((Rect)(ref trimmedBounds)).x, j - (int)((Rect)(ref trimmedBounds)).y, orig.GetPixel(i, j));
			}
		}
		val.Apply(false, false);
		return val;
	}

	public static Rect GetTrimmedBounds(this Texture2D t)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		int num = ((Texture)t).width;
		int num2 = ((Texture)t).height;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < ((Texture)t).width; i++)
		{
			for (int j = 0; j < ((Texture)t).height; j++)
			{
				if (t.GetPixel(i, j) != Color.clear)
				{
					if (i < num)
					{
						num = i;
					}
					if (j < num2)
					{
						num2 = j;
					}
					if (i > num3)
					{
						num3 = i;
					}
					if (j > num4)
					{
						num4 = j;
					}
				}
			}
		}
		return new Rect((float)num, (float)num2, (float)(num3 - num + 1), (float)(num4 - num2 + 1));
	}

	public static Texture2D AddMargin(this Texture2D texture)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Texture2D val = new Texture2D(((Texture)texture).width + 2 * padding, ((Texture)texture).height + 2 * padding);
		((Object)val).name = ((Object)texture).name;
		((Texture)val).filterMode = ((Texture)texture).filterMode;
		for (int i = 0; i < ((Texture)val).width; i++)
		{
			for (int j = 0; j < ((Texture)val).height; j++)
			{
				val.SetPixel(i, j, Color.clear);
			}
		}
		for (int k = 0; k < ((Texture)texture).width; k++)
		{
			for (int l = 0; l < ((Texture)texture).height; l++)
			{
				val.SetPixel(k + padding, l + padding, texture.GetPixel(k, l));
			}
		}
		val.Apply(false, false);
		return val;
	}

	public static Texture2D GetReadable(this Texture2D texture)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		RenderTexture temporary = RenderTexture.GetTemporary(((Texture)texture).width, ((Texture)texture).height, 0, (RenderTextureFormat)7, (RenderTextureReadWrite)1);
		Graphics.Blit((Texture)(object)texture, temporary);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = temporary;
		Texture2D val = new Texture2D(((Texture)texture).width, ((Texture)texture).height);
		val.ReadPixels(new Rect(0f, 0f, (float)((Texture)temporary).width, (float)((Texture)temporary).height), 0, 0);
		val.Apply();
		RenderTexture.active = active;
		return val;
	}

	public static Texture2D Rotated(this Texture2D texture, bool clockwise = false)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		Color32[] pixels = texture.GetPixels32();
		Color32[] array = (Color32[])(object)new Color32[pixels.Length];
		int width = ((Texture)texture).width;
		int height = ((Texture)texture).height;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				int num = (j + 1) * height - i - 1;
				int num2 = (clockwise ? (pixels.Length - 1 - (i * width + j)) : (i * width + j));
				array[num] = pixels[num2];
			}
		}
		Texture2D val = new Texture2D(height, width);
		val.SetPixels32(array);
		val.Apply();
		return val;
	}

	public static Texture2D Flipped(this Texture2D texture, bool horizontal = true)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		int width = ((Texture)texture).width;
		int height = ((Texture)texture).height;
		Texture2D val = new Texture2D(width, height);
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				val.SetPixel(i, j, texture.GetPixel(width - i - 1, j));
			}
		}
		val.Apply();
		return val;
	}
}
