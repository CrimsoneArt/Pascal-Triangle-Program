using Godot;

public partial class RowHolder : VBoxContainer
{
	[Export]
	public int Rows { get; set; } = 1;

	private PackedScene _numberHolderScene = GD.Load<PackedScene>("res://NumberHolder.tscn");

	public override void _Ready()
	{
		
		for (int i = 0; i < Rows; i++)
		{
			var numberHolderInstance = _numberHolderScene.Instantiate();
			numberHolderInstance.Name = "NumberHolder" + i;
			
			// Assumes NumberHolder script has these properties defined
			numberHolderInstance.Set("id", i);
			numberHolderInstance.Set("numbers", i + 1);
			
			AddChild(numberHolderInstance);
		}
	}
}
