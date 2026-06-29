using Godot;

public partial class Main : Node
{
	public override void _Ready()
	{
		GD.Print("Hello, world!");
	}
	
	private double _t = 0.0;

	public override void _Process(double delta)
	{
		GetNode<Label>("Label").Text = _t.ToString();
		_t += 5.0 * delta;
	}
}
