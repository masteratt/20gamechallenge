using Godot;

public partial class Paddle : CharacterBody2D
{
    private Vector2 _inputDirection;
    [Export] private float _speed = 1000f;

    public override void _Process(double delta)
    {
        _inputDirection = Input.GetVector("left", "right", "ui_page_up", "ui_page_down");
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = _inputDirection * _speed;
        MoveAndSlide();
    }
}