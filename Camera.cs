using Godot;

public partial class Camera : Camera2D
{
	[Export] public float ZoomSpeed { get; set; } = 0.1f;
	[Export] public Vector2 MinZoom { get; set; } = new Vector2(0.02f, 0.02f);
	[Export] public Vector2 MaxZoom { get; set; } = new Vector2(100.0f, 100.0f);

	private bool _isDragging = false;
	private Vector2 _lastMousePosition;

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left)
			{
				_isDragging = mouseButton.Pressed;
				if (_isDragging)
				{
					_lastMousePosition = GetLocalMousePosition();
				}
			}
			else if (mouseButton.Pressed)
			{
				if (mouseButton.ButtonIndex == MouseButton.WheelUp)
				{
					ZoomToMouse(1.0f + ZoomSpeed);
				}
				else if (mouseButton.ButtonIndex == MouseButton.WheelDown)
				{
					ZoomToMouse(1.0f - ZoomSpeed);
				}
			}
		}
	}

	public override void _Process(double delta)
	{
		if (_isDragging)
		{
			Vector2 currentMousePosition = GetLocalMousePosition();
			Position -= (currentMousePosition - _lastMousePosition);
			_lastMousePosition = GetLocalMousePosition();
		}
	}

	private void ZoomToMouse(float factor)
	{
		Vector2 oldZoom = Zoom;
		Vector2 newZoom = (oldZoom * factor).Clamp(MinZoom, MaxZoom);

		if (oldZoom == newZoom) return;

		Vector2 mousePos = GetGlobalMousePosition();
		
		Zoom = newZoom;
		
		Position += mousePos - GetGlobalMousePosition();
	}
}
