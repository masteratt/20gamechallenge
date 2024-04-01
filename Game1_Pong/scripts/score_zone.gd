extends Area2D


@export var is_player_score_zone: bool


func _on_body_entered(body: Node2D) -> void:
	if !body is Ball:
		return
		
	var ball: Ball = body as Ball
	
	if is_player_score_zone:
		GameMaster.player_score += 1
	else:
		GameMaster.cpu_score += 1
	
	ball.start_ball()
