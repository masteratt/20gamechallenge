using Godot;

public partial class Ball : Area2D
{
    private Vector2 _velocity = new(0, 600);

    public override void _PhysicsProcess(double delta)
    {
        Position += _velocity * (float)delta;
    }

    public void OnBallBodyEntered(Node2D area)
    {
        GD.Print("paddle");

        if (area is not Paddle paddle) return;

        // Calculate new direction based on where the ball hit the paddle
        var hitPos = (GlobalPosition.X - paddle.GlobalPosition.X) /
                     (paddle.GetNode<Sprite2D>("Sprite2D").Texture.GetWidth() / 2);
        // Increase the speed of the ball after it hits the paddle
        _velocity = new Vector2(hitPos, -1).Normalized() * 500; // Adjust this value as needed
    }
}