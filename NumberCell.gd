extends Button

@export var numbers_above := Vector2i(0,0)

@export var id := 0

var number := 0

@export var max_font_size: int = 32
@export var min_font_size: int = 0

func _ready() -> void:
	number = numbers_above.x + numbers_above.y
	
	text = str(number)
	
	clip_text = true
	
	change_color(number)
	
	if number < 0 or numbers_above.x < 0 or numbers_above.y < 0:
		text = ":("
		var style_box = StyleBoxFlat.new()
		var color = Color(0.0,0.0,0.0)
	
		style_box.bg_color = color
		set("theme_override_styles/disabled",style_box)
		set("theme_override_colors/font_disabled_color",Color(1.0,1.0,1.0))
		
	adjust_font_size()

func adjust_font_size() -> void:
	var font = get_theme_font("font")
	var current_size = max_font_size
	
	# Account for internal button padding/margins
	var padding_x = get_theme_constant("h_separation") * 2
	var usable_width = size.x - padding_x
	
	while current_size >= min_font_size:
		add_theme_font_size_override("font_size", current_size)
		
		var text_size = font.get_string_size(text, alignment, -1, current_size)
		
		if text_size.x <= usable_width:
			break
			
		current_size -= 1

#var t = 0.0
#
#func _process(delta):
	#t = get_nodse("/root/Main").t
	#change_color(number)

func change_color(n):
	var style_box = StyleBoxFlat.new()
	var color: Color
	#this is where you make your custom functions
	
	#var r = (sin(n)+1)/2.0
	#var g = (cos(n)+1)/2.0
	#var b = (tan(n)+1)/2.0
	#color = Color(r,g,b)
	
	style_box.bg_color = color
	set("theme_override_styles/disabled",style_box)
	if (color.r+color.g+color.b)/3.0 >= 0.75:
		set("theme_override_colors/font_disabled_color",Color(0.0,0.0,0.0))
	
