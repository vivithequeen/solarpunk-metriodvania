using Godot;
using System;
using System.IO.Pipes;

public partial class Player_die : Area2D
{
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		// connect the Area2D BodyEntered signal so we can detect when the player enters
		BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void OnBodyEntered(Node body)
	{
		// If the entering body is the player CharacterBody2D, move them back to (0,0)
		if (body is CharacterBody2D cb && cb.Name == "Player")
		{
			cb.GlobalPosition = new Vector2(0, 0);
			GD.Print("Player entered death area — respawned to (0,0)");
		}
	}
}
