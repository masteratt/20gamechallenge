using Godot;

public partial class Block : StaticBody2D
{
    private Sprite2D _sprite;

    public override void _Ready()
    {
        _sprite = GetNode<Sprite2D>("Sprite2D");
    }

    public Vector2 GetBlockSize()
    {
        return _sprite.Texture.GetSize();
    }
}