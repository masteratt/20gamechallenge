extends CanvasLayer

@onready var player_score_label: Label = $Control/PlayerScore
@onready var cpu_score_label: Label = $Control/CpuScore

func _ready() -> void:
	GameMaster.player_score_changed.connect(on_player_score_change)
	GameMaster.cpu_score_changed.connect(on_cpu_score_change)
	
	
func on_player_score_change() -> void:
	player_score_label.text = str(GameMaster.player_score)


func on_cpu_score_change() -> void:
	cpu_score_label.text = str(GameMaster.cpu_score)
