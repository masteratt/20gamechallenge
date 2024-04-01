extends CharacterBody2D

var speed: float = 800

func get_input() -> void:
	if Input.is_action_pressed("up"):
		velocity.y = -speed
	elif Input.is_action_pressed("down"):
		velocity.y = speed
	else:
		velocity.y = 0


func _process(_delta: float) -> void:
	get_input()
	move_and_slide()
