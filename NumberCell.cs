using Godot;

public partial class NumberCell : Button
{
	public System.Numerics.BigInteger X { get; set; }
	public System.Numerics.BigInteger Y { get; set; }

	[Export]
	public int id { get; set; } = 0;

	[Export]
	public int MaxFontSize { get; set; } = 32;

	[Export]
	public int MinFontSize { get; set; } = 0;

	public System.Numerics.BigInteger number = System.Numerics.BigInteger.Parse("0");

	public override void _Ready()
	{
		
		number = X + Y;

		Text = number.ToString();

		ClipText = true;

		ChangeColor(number);

		if (number < 0 || X < 0 || Y < 0)
		{
			Text = ":(";
			var styleBox = new StyleBoxFlat();
			var color = new Color(0.0f, 0.0f, 0.0f);

			styleBox.BgColor = color;
			Set("theme_override_styles/disabled", styleBox);
			Set("theme_override_colors/font_disabled_color", new Color(1.0f, 1.0f, 1.0f));
		}

		AdjustFontSize();
	}

	public void AdjustFontSize()
	{
		var font = GetThemeFont("font");
		int currentSize = MaxFontSize;

		int paddingX = GetThemeConstant("h_separation") * 2;
		float usableWidth = Size.X - paddingX;

		while (currentSize >= MinFontSize)
		{
			AddThemeFontSizeOverride("font_size", currentSize);

			Vector2 textSize = font.GetStringSize(Text, Alignment, -1, currentSize);

			if (textSize.X <= usableWidth)
			{
				break;
			}

			currentSize--;
		}
	}

	public void ChangeColor(System.Numerics.BigInteger n)
	{
		var styleBox = new StyleBoxFlat();
		Color color = new Color(0.0f,0.0f,0.0f,1.0f);

		if (n%3==0)
		{
			color = new Color(1.0f,0.0f,0.0f,1.0f);
		} else {
			if (n%3==1) 
			{
				color = new Color(0.0f,0.0f,1.0f,1.0f);
			}
		}

		styleBox.BgColor = color;
		Set("theme_override_styles/disabled", styleBox);
		
		if ((color.R + color.G + color.B) / 3.0f >= 0.75f)
		{
			Set("theme_override_colors/font_disabled_color", new Color(0.0f, 0.0f, 0.0f));
		}
	}
}
