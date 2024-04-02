extends CharacterBody2D

var speed: float = 30


func _process(_delta: float) -> void:
	velocity.x = 0 # Even with this the paddles moves back after colliding with ball in its corner.
	if Input.is_action_pressed("up"):
		velocity.y = -speed
	elif Input.is_action_pressed("down"):
		velocity.y = speed
	else:
		velocity.y = 0


func _physics_process(delta: float) -> void:
	move_and_collide(velocity * speed * delta)
