using Godot;

public partial class FPS : Control
{
    [Export] private Label _fpsLabel;

    public override void _Process(double delta)
    {
        var frameTimeMs = 1000.0 / Engine.GetFramesPerSecond();
        frameTimeMs = (int)(frameTimeMs * 100) / 100.0;
        _fpsLabel.Text = $"FPS: {Engine.GetFramesPerSecond()} ({frameTimeMs:F2}ms)";
    }
}