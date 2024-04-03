class_name Ball extends CharacterBody2D

var initial_ball_speed: float = 20
var speed_multiplier: float = 1.02
@onready var ball_start_area: Marker2D = $"../BallStartArea"

var ball_speed: float = initial_ball_speed

func _ready() -> void:
	start_ball()
	

func _physics_process(delta: float) -> void:	
	var collision: KinematicCollision2D = move_and_collide(velocity * ball_speed * delta)
	
	if (collision):
		velocity = velocity.bounce(collision.get_normal()) * speed_multiplier
	
	
func start_ball() -> void:
	global_position = ball_start_area.global_position
	randomize()
	velocity.x = [-1, 1].pick_random() * initial_ball_speed
	velocity.y = [-.8, .8].pick_random() * initial_ball_speed
