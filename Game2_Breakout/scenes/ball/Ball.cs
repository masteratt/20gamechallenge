using Godot;

public partial class Ball : RigidBody2D
{
    private float _initialSpeed = 300;
    private Vector2 _screenSize;
    private Vector2 _velocity;

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        _velocity = new Vector2(0, _initialSpeed);
        GravityScale = 0; // Disable gravity
        LinearVelocity = _velocity; // Set initial velocity
    }

    public override void _PhysicsProcess(double delta)
    {
        // Move the ball and get the collision information
        var collision = MoveAndCollide(_velocity * (float)delta);

        // If the ball collided with a block, adjust its velocity based on the collision normal
        if (collision != null)
        {
            if (collision.GetCollider() is Block block)
            {
                if (Mathf.Abs(collision.GetNormal().X) > Mathf.Abs(collision.GetNormal().Y))
                    // The ball hit the left or right side of the block
                    _velocity.X = -_velocity.X;
                else
                    // The ball hit the top or bottom of the block
                    _velocity.Y = -_velocity.Y;
                block.QueueFree();
            }
            else if (collision.GetCollider() is Paddle paddle)
            {
                var hitPosition = (GlobalPosition.X - paddle.GlobalPosition.X) / (paddle.SpriteWidth / 2);
                _velocity = new Vector2(hitPosition, -1).Normalized() * _initialSpeed;
            }
        }

        // Check if the ball is out of bounds and adjust its velocity if necessary
        if (Position.X < 0 || Position.X > _screenSize.X)
            _velocity.X = -_velocity.X;
        if (Position.Y < 0)
            _velocity.Y = -_velocity.Y;

        LinearVelocity = _velocity; // Update the ball's LinearVelocity with the new velocity vector
        LinearVelocity = LinearVelocity.Normalized() * _initialSpeed; // Ensure the ball's speed remains constant
    }
}