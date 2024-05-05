using Godot;

public partial class BlockGenerator : Node
{
    [Export] private Vector2 _blockOffset = new(32, 32);
    [Export] private PackedScene _blockScene;
    [Export] private Vector2 _blockSize = new(64, 32);
    [Export] private Vector2 _blockSpacing = new(8, 8);
    [Export] private int _columns = 10;
    [Export] private int _rows = 5;

    public override void _Ready()
    {
        for (var row = 0; row < _rows; row++)
        for (var column = 0; column < _columns; column++)
        {
            var block = (Block)_blockScene.Instantiate();
            block.Position = new Vector2(column * (_blockSize.X + _blockSpacing.X) + _blockOffset.X,
                row * (_blockSize.Y + _blockSpacing.Y) + _blockOffset.Y);
            AddChild(block);
        }
    }
}