using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Export] private float gravity = 300;
	[Export] private float speed = 100;
	[Export] private float jumpForce = 200;
	
	private AnimatedSprite2D animatedSprite;
	private float direction = 0;
	
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Movement(delta);
		UpdateAnimations(delta);
	}

	private void UpdateAnimations(double delta)
	{
		if (direction != 0)
			animatedSprite.FlipH = direction == -1;

		if (IsOnFloor())
		{
			animatedSprite.Play(direction == 0 ? "idle" : "run");
		}
		else
		{
			animatedSprite.Play(Velocity.Y < 0 ? "jump" : "fall");
		}
	}

	private void Movement(double delta)
	{
		var velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			if (velocity.Y > 500)
				velocity.Y = 500;
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = -jumpForce;
		}
		
		direction = Input.GetAxis("move_left", "move_right");
		velocity.X = direction * speed;
		Velocity = velocity;
		MoveAndSlide();
	}

	public void Jump(float force)
	{
		var velocity = new Vector2
		{
			Y = -force
		};
		Velocity = velocity;
	}
}
