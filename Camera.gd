extends Camera2D

var speed = 400.0
var zoom_speed = 0.5

func _process(delta):
	if Input.is_action_pressed("ui_up"):
		position.y -= delta * speed * (1/zoom.x)
	if Input.is_action_pressed("ui_down"):
		position.y += delta * speed * (1/zoom.x)
	if Input.is_action_pressed("ui_left"):
		position.x -= delta * speed * (1/zoom.x)
	if Input.is_action_pressed("ui_right"):
		position.x += delta * speed * (1/zoom.x)
	if Input.is_action_pressed("zoom_in"):
		zoom = Vector2(zoom.x+zoom_speed*delta,zoom.y+zoom_speed*delta)
	if Input.is_action_pressed("zoom_out"):
		zoom = Vector2(zoom.x-zoom_speed*delta,zoom.y-zoom_speed*delta)
