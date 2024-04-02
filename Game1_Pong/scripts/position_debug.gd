extends Control

@export var node_im_tracking: Node2D
@onready var x_value: Label = $VBoxContainer/HBoxContainer/xValue
@onready var y_value: Label = $VBoxContainer/HBoxContainer2/yValue

func _process(delta: float) -> void:
	x_value.text = str(node_im_tracking.global_position.x)
	y_value.text = str(node_im_tracking.global_position.y)
