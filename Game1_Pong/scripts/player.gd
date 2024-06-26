extends CharacterBody2D

var speed: float = 500

func _physics_process(_delta: float) -> void:
	var direction: float = Input.get_axis("up", "down")
	if direction:
		velocity.y = direction * speed
	else:
		velocity.y = move_toward(velocity.y, 0, speed)

	move_and_slide()
