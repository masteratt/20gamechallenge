using Godot;

public partial class Paddle : CharacterBody2D
{
    private float _adjustedSpriteWidth;
    private Vector2 _inputDirection;
    private Vector2 _screenSize;
    [Export] private float _moveSpeed = 1000f;

    public float SpriteWidth => GetNode<Sprite2D>("Sprite2D").Texture.GetWidth();

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        var spriteScale = GetNode<Sprite2D>("Sprite2D").Scale.X;
        _adjustedSpriteWidth = SpriteWidth * spriteScale;
    }

    public override void _Process(double delta)
    {
        _inputDirection = new Vector2(Input.GetActionStrength("right") - Input.GetActionStrength("left"), 0);
    }

    public override void _PhysicsProcess(double delta)
    {
        var newVelocity = _inputDirection * _moveSpeed;
        newVelocity.Y = 0; // Ensure the paddle never moves on the y axis
        Velocity = newVelocity;
        MoveAndSlide();

        // Check if the paddle is out of bounds and adjust its position if necessary
        if (Position.X - _adjustedSpriteWidth / 2 < 0)
            Position = new Vector2(_adjustedSpriteWidth / 2, Position.Y);
        else if (Position.X + _adjustedSpriteWidth / 2 > _screenSize.X)
            Position = new Vector2(_screenSize.X - _adjustedSpriteWidth / 2, Position.Y);
    }
}