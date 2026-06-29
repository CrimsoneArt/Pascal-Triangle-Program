extends VBoxContainer

@export var rows := 1

var number_holder_scene := preload("res://NumberHolder.tscn")

func _ready():
	for i in range(0,rows):
		var number_holder_instance := number_holder_scene.instantiate()
		number_holder_instance.name = "NumberHolder" + str(i)
		number_holder_instance.id = i
		number_holder_instance.numbers = i+1
		add_child(number_holder_instance)
		
