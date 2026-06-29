extends Control

var t = 0.0
func _process(delta):
	$Label.text = str(t)
	t += 5.0*delta
