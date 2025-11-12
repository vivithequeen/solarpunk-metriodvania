using System;
using Godot;

public partial class Movement : CharacterBody2D
{
	[Export] public float MaxSpeed = 600f;
	[Export] public float JumpForce = 90f;
	[Export] public float Gravity = 5000f;
	[Export] public float Acceleration = 80f;

	double timeSinceJump = 0;
	float speed = 0;
	bool inJump = false;

	private Vector2 velocity = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		// Apply gravity
		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;
			
		}
		else
		{
			inJump = false;
			velocity.Y = 0; // Reset Y velocity when grounded
			timeSinceJump = 0;
			
		}
		if (IsOnCeiling())
		{
			inJump = true;
			velocity.Y = 10;
		}

		// Get input for horizontal movement
		if (Input.IsActionPressed("Right"))
		{
			speed = MaxSpeed;
		}
		else if (Input.IsActionPressed("Left"))
		{
			speed = -MaxSpeed;
		}
		else
		{
			speed = 0;
		}

		velocity.X = speed;

		// Jumping
		if (inJump == false && timeSinceJump <= 0.25 && Input.IsActionPressed("Jump"))
		{
			timeSinceJump += delta;
			if (timeSinceJump <= 0.03)
			{
				velocity.Y -= 400;
			}
			else if (timeSinceJump <= 0.1)
			{
				velocity.Y -= 220;
			}
			velocity.Y -= JumpForce;
		}
		else if (inJump == false && timeSinceJump <= 0.25 && Input.IsActionJustReleased("Jump"))
		{
			inJump = true;
			velocity.Y += 600;
		}


		// Move the player
		Velocity = velocity;
		MoveAndSlide();
	}
}
