using Godot;
using System;

public partial class JumpPad : Area2D
{

	[Export] private float jumpForce = 300;
	private AnimatedSprite2D animatedSprite2D;
	
	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	
	private void OnBodyEntered(Node body)
	{
		if (body is player)
		{
			animatedSprite2D.Play("jump");
			var player = (player)body;
			player.Jump(jumpForce);
		}
	}
}
