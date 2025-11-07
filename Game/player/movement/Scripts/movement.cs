using Godot;

public partial class Player : CharacterBody2D
{
	// Movement and gravity variables
	[Export] public float Speed = 200f; // Horizontal movement speed
	[Export] public float JumpForce = 50f; // Jump strength
	[Export] public float Gravity = 900f; // Gravity strength

	bool inJump = true;

	private Vector2 velocity = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		// Apply gravity
		velocity.Y += Gravity * (float)delta;

		// Get input for horizontal movement
		float direction = Input.GetActionStrength("Right") - Input.GetActionStrength("Left");
		velocity.X = direction * Speed;

		// Jumping logic
		if (inJump && Input.IsActionPressed("Jump"))
		{
			if (velocity.Y <= 900)
			{
				inJump = true;
				velocity.Y -= JumpForce;
			}
			else
			{
				inJump = false;
			}
		}

		// Move the character
		MoveAndSlide();
	}
}
