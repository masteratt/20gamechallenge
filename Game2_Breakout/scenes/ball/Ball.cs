using Godot;

public partial class Ball : RigidBody2D
{
    public override void _Ready()
    {
        LinearVelocity = new Vector2(0, 600);
    }

    public void OnBallBodyEntered(Node body)
    {
        GD.Print("paddle");

        if (body is not Paddle paddle) return;
        
        
        // Calculate new direction based on where the ball hit the paddle
        var hitPos = (GlobalPosition.X - paddle.GlobalPosition.X) /
                     (paddle.GetNode<Sprite2D>("Sprite2D").Texture.GetWidth() / 2);
        // Increase the speed of the ball after it hits the paddle
        LinearVelocity = new Vector2(hitPos, -1).Normalized() * 500; // Adjust this value as needed
    }
}