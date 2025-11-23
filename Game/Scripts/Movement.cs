using System;
using System.Drawing;
using Godot;

public partial class Movement : CharacterBody2D
{
	[Export] public float MaxSpeed = 700f;
	[Export] public float JumpForce = 65f;
	[Export] public float Gravity = 5000f;
	[Export] public float Acceleration = 80f;
	

	double timeSinceJump = 0;
	float speed = 0;
	bool inJump = false;

	private Vector2 velocity = Vector2.Zero;
	private AnimatedSprite2D _animPlayer;

	public override void _Ready()
	{
		// Get the AnimationPlayer node
		_animPlayer = GetNode<AnimatedSprite2D>("Player");
	}

	public override void _Process(double delta)
	{
		var gunAncor = GetNode<Node2D>("gun_ancor");
		gunAncor.Position = new Vector2(45 * (Velocity.X > 0 ? 1 : -1), gunAncor.Position.Y);
		if (IsOnCeiling())
		{
			inJump = true;
			velocity.Y = 10;
		}

		// Get input for horizontal movement
		if (Input.IsActionPressed("Right"))
		{
			speed = MaxSpeed;
			_animPlayer.FlipH = false;
			if (inJump == false)
			{
				_animPlayer.Play("Running");
			}
		}
		else if (Input.IsActionPressed("Left"))
		{
			speed = -MaxSpeed;
			_animPlayer.FlipH = true;
			if (inJump == false)
			{
				_animPlayer.Play("Running");
			}
		}
		else
		{
			speed = 0;
			if (inJump == false)
			{
				_animPlayer.Play("Idling");
			}
		}
		// Apply gravity
		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;
			_animPlayer.Play("Jumping_down");
			if (velocity.Y > 0){
				inJump = true;
			}

		}
		else
		{
			velocity.Y = 0; // Reset Y velocity when grounded
			timeSinceJump = 0;
			inJump = false;
			
		}
		if (Velocity.Y > 0)
		{
			_animPlayer.Play("Jumping_down");
		}


		velocity.X = speed;

		// Jumping
		if (inJump == false && timeSinceJump <= 0.25 && Input.IsActionPressed("Jump"))
		{
			_animPlayer.Play("Jumping_up");
			timeSinceJump += delta;
			if (timeSinceJump <= 0.03)
			{
				velocity.Y -= 400 * (float)delta * 60;
			}
			else if (timeSinceJump <= 0.1)
			{
				velocity.Y -= 220 * (float)delta * 60;
			}
			velocity.Y -= JumpForce * (float)delta * 60;
		}
		else if (inJump == false && timeSinceJump <= 0.25 && Input.IsActionJustReleased("Jump"))
		{
			inJump = true;
			velocity.Y += 600 * (float)delta * 60;
		}

		if (velocity.Y >= 2000)
		{
			velocity.Y = 2000;
		}


		// Move the player
		Velocity = velocity;
		MoveAndSlide();
	}
}
