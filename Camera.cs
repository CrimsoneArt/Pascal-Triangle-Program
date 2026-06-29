using Godot;

public partial class Camera : Camera2D
{
	private float _speed = 400.0f;
	private float _zoomSpeed = 0.5f;

	public override void _Process(double delta)
	{
		float fDelta = (float)delta;

		if (Input.IsActionPressed("ui_up"))
		{
			Position = new Vector2(Position.X, Position.Y - fDelta * _speed * (1.0f / Zoom.X));
		}
		if (Input.IsActionPressed("ui_down"))
		{
			Position = new Vector2(Position.X, Position.Y + fDelta * _speed * (1.0f / Zoom.X));
		}
		if (Input.IsActionPressed("ui_left"))
		{
			Position = new Vector2(Position.X - fDelta * _speed * (1.0f / Zoom.X), Position.Y);
		}
		if (Input.IsActionPressed("ui_right"))
		{
			Position = new Vector2(Position.X + fDelta * _speed * (1.0f / Zoom.X), Position.Y);
		}
		if (Input.IsActionPressed("zoom_in"))
		{
			Zoom = new Vector2(Zoom.X + _zoomSpeed * fDelta, Zoom.Y + _zoomSpeed * fDelta);
		}
		if (Input.IsActionPressed("zoom_out"))
		{
			Zoom = new Vector2(Zoom.X - _zoomSpeed * fDelta, Zoom.Y - _zoomSpeed * fDelta);
		}
	}
}
