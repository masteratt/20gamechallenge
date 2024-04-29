using Godot;

public partial class Paddle : CharacterBody2D
{
    private Vector2 _inputDirection;
    [Export] private float _speed = 1000f;
    
    public override void _Process(double delta)
    {
        _inputDirection = new Vector2(Input.GetActionStrength("right") - Input.GetActionStrength("left"), 0);
    }

    public override void _PhysicsProcess(double delta)
    {
        var newVelocity = _inputDirection * _speed;
        newVelocity.Y = 0; // Ensure the paddle never moves on the y axis
        Velocity = newVelocity;
        MoveAndSlide();
    }
}