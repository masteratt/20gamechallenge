extends Node

signal player_score_changed
signal cpu_score_changed

var player_score: int = 0:
	set(value):
		player_score = value
		player_score_changed.emit()

var cpu_score: int = 0:
	set(value):
		cpu_score = value
		cpu_score_changed.emit()
