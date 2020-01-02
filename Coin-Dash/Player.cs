using Godot;
using System;

public class Player : Area2D
{
    // How fast the player will move (pixels/sec).
    [Export]
    public int Speed = 400;

    // Size of the game window.
    private Vector2 screenSize;
    // The player's movement vector.
    private Vector2 velocity;

    public override void _Ready()
    {
        screenSize = GetViewport().GetSize();
    }

    public override void _Process(float delta)
    {
        _GetInput();

        Position += velocity * delta;

        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, screenSize.x),
            y: Mathf.Clamp(Position.y, 0, screenSize.y)
        );

    }

    private void _GetInput()
    {
        velocity = new Vector2();

        if (Input.IsActionPressed("ui_right"))
        {
            velocity.x += 1;
        }

        if (Input.IsActionPressed("ui_left"))
        {
            velocity.x -= 1;
        }

        if (Input.IsActionPressed("ui_down"))
        {
            velocity.y += 1;
        }

        if (Input.IsActionPressed("ui_up"))
        {
            velocity.y -= 1;
        }

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }
    }
}
