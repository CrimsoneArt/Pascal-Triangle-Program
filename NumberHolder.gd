extends HBoxContainer

@export var numbers := 0

@export var id := 0

var number_cell_scene := preload("res://NumberCell.tscn")

func _ready():
	for i in range(0,numbers):
		var number_cell_instance := number_cell_scene.instantiate()
		number_cell_instance.name = "NumberCell" + str(i)
		var number_holder_above = get_parent().get_node("NumberHolder" + str(id-1))
		var number_cell_above_1 : Node
		var number_cell_above_2 : Node
		if number_holder_above != null:
			number_cell_above_1 = number_holder_above.get_node("NumberCell" + str(i-1))
			number_cell_above_2 = number_holder_above.get_node("NumberCell" + str(i))
			
			number_cell_instance.numbers_above = Vector2i(number_cell_above_1.number if number_cell_above_1 != null else 0,number_cell_above_2.number if number_cell_above_2 != null else 0)
		else:
			number_cell_instance.numbers_above = Vector2i(0,1)
		add_child(number_cell_instance)
