using System;
using System.Drawing;
using Godot;

public partial class Movement : CharacterBody2D
{
	[Export] public float MaxSpeed = 700f;
	[Export] public float JumpForce = 65f;
	[Export] public float Gravity = 5000f;
	[Export] public float Acceleration = 80f;
	// How far below the player we'll still consider the player "on" the ground
	[Export] public float GroundTolerance = 127f;
	

	double timeSinceJump = 0;
	float speed = 0;
	bool inJump = false;
	bool inSlide = false;

	private Vector2 velocity = Vector2.Zero;
	private AnimatedSprite2D _animPlayer;
	private CollisionShape2D _colider;
	private Area2D _arm_top_ancor;
	private Area2D _arm_bottom_ancor;

	// returns true when a surface exists within GroundTolerance pixels below the player
	private bool IsNearFloor(float tolerance)
	{
		var from = GlobalPosition;
		var to = GlobalPosition + new Vector2(0, tolerance);
		var exclude = new Godot.Collections.Array<Rid>() { this.GetRid() };

		// Godot 4's C# API expects a PhysicsRayQueryParameters2D for IntersectRay
		var query = new PhysicsRayQueryParameters2D();
		query.From = from;
		query.To = to;
		query.Exclude = exclude;

		var result = GetWorld2D().DirectSpaceState.IntersectRay(query);
		return result.Count > 0;
	}

	public override void _Ready()
	{
		// Get the AnimationPlayer node
		_animPlayer = GetNode<AnimatedSprite2D>("Player");
		_colider = GetNode<CollisionShape2D>("Colider");
		_arm_top_ancor = GetNode<Area2D>("arm_top_ancor");
		_arm_bottom_ancor = GetNode<Area2D>("arm_bottom_ancor");
	}

	public override void _Process(double delta)
	{
		_colider.Scale = new Vector2(1, 1);
		var gunAncor = GetNode<Node2D>("gun_ancor");
		if (Velocity.X != 0)
		{
			gunAncor.Position = new Vector2(45 * (Velocity.X > 0 ? 1 : -1), gunAncor.Position.Y);
		}
		if (IsOnCeiling())
		{
			inJump = true;
			velocity.Y = 10;
		}

		if (!inSlide)
		{
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

		// allow a small tolerance so the player can still slide if the collider is just slightly above the floor
		if (Input.IsActionPressed("Down") && IsNearFloor(GroundTolerance))
		{
			if (_animPlayer.FlipH == true)
            {
                speed = -MaxSpeed * 2f;
            }
			else
			{
				speed = MaxSpeed * 2f;
			}

			_colider.Scale /= 1.5f;
			inSlide = true;
			_animPlayer.Play("Sliding");
        }
		if (Input.IsActionJustReleased("Down"))
		{
			inSlide = false;
		}

		velocity.X = speed;

		// Jumping
		if (!inJump && timeSinceJump <= 0.25 && Input.IsActionPressed("Jump"))
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
		else if (!inJump && timeSinceJump <= 0.25 && Input.IsActionJustReleased("Jump"))
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
