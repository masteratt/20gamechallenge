extends CharacterBody2D

var speed : int = 300.0
@export var ball : Ball
var direction: float
	
func _physics_process(_delta: float) -> void:
	
	direction = get_ai_direction()
	print("cpu direction: " + str(direction))
	velocity.y = direction * speed
	
	move_and_slide()
	
func get_ai_direction() -> int:	
	print(ball.velocity.x)
	if (ball.velocity.x < 0):
		return 0
	if abs(ball.global_position.y - global_position.y) > 10:
		if ball.global_position.y > global_position.y:
			return 1
		else:
			return -1
	else: 
		return 0
