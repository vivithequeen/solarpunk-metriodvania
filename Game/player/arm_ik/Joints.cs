using Godot;
using System;
using System.IO.Pipes;

public partial class Joints : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Position = GetGlobalMousePosition();
        Rotation = (GetGlobalMousePosition() - GlobalPosition).Angle();
        GD.Print(Position);
		
	}
}
