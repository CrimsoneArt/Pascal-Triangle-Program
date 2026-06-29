using Godot;

public partial class NumberHolder : HBoxContainer
{
	[Export]
	public int numbers { get; set; } = 0;

	[Export]
	public int id { get; set; } = 0;

	private PackedScene _numberCellScene = GD.Load<PackedScene>("res://NumberCell.tscn");

	public override void _Ready()
	{
		for (int i = 0; i < numbers; i++)
		{
			var numberCellInstance = _numberCellScene.Instantiate();
			numberCellInstance.Name = "NumberCell" + i;

			var numberHolderAbove = GetParent().GetNodeOrNull("NumberHolder" + (id - 1));
			if (numberCellInstance is NumberCell cell) 
			{
				if (numberHolderAbove != null)
				{
					var numberCellAbove1 = numberHolderAbove.GetNodeOrNull("NumberCell" + (i - 1)) as NumberCell;
					var numberCellAbove2 = numberHolderAbove.GetNodeOrNull("NumberCell" + i) as NumberCell;
					
					System.Numerics.BigInteger X = numberCellAbove1 != null ? numberCellAbove1.number : System.Numerics.BigInteger.Zero;
					System.Numerics.BigInteger Y = numberCellAbove2 != null ? numberCellAbove2.number : System.Numerics.BigInteger.Zero;
					
					cell.X = X;
					cell.Y = Y;
				}
				else
				{
					cell.X = System.Numerics.BigInteger.Zero;
					cell.Y = System.Numerics.BigInteger.One;
				}
			}
			AddChild(numberCellInstance);
		}
	}
}
