extends Control

var row_holder_scene = load("res://RowHolder.tscn")

func _on_regenerate_button_pressed() -> void:
	$RowHolder.queue_free()
	add_child(row_holder_scene.instantiate())
