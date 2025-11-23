using Godot;
using System;
using System.IO.Pipes;

public partial class Gun : Node2D
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	Sprite2D GunSprite;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        Rotation = (GetGlobalMousePosition() - GlobalPosition).Angle();

        GunSprite.FlipV = !(Rotation < Math.PI / 2 && Rotation > Math.PI / -2);
		GD.Print(Rotation);

    }
}
