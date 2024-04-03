class_name Ball extends RigidBody2D

var initial_ball_speed: float = 500
var speed_multiplier: float = 1.02
@onready var ball_start_area: Marker2D = $"../BallStartArea"

var ball_speed: float = initial_ball_speed

var freeze_physics: bool = true

func _ready() -> void:	
	start_ball()
	
	
func start_ball() -> void:
	transform = Transform2D(0.0, Vector2(ball_start_area.global_position.x, ball_start_area.global_position.y))
	var x_force: float = [-1, 1].pick_random() * initial_ball_speed;
	var y_force: float = [-.8, .8].pick_random() * initial_ball_speed;
	linear_velocity = Vector2(x_force, y_force)

func reset() -> void:
	queue_free()	
	var newCopy: Node = duplicate()
	get_parent().add_child.bind(newCopy).call_deferred()
