using Godot;
using System;

public partial class level : Node2D
{
	private Marker2D startPosition;
	private CharacterBody2D player;
	
	public override void _Ready()
	{
		player = GetNode<CharacterBody2D>("Player");
		startPosition = GetNode<Marker2D>("StartPosition");

		player.GlobalPosition = startPosition.GlobalPosition;
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("quit"))
		{
			GetTree().Quit();
		}
		else if (Input.IsActionJustPressed("reset"))
		{
			GetTree().ReloadCurrentScene();
		}
	}
	
	// signal from DeathZone
	private void OnDeathZoneEntered(Node2D body)
	{
		ResetPlayer((CharacterBody2D)body);
	}

	private void OnTrapTouchedPlayer(CharacterBody2D player)
	{
		ResetPlayer(player);
	}

	private void ResetPlayer(CharacterBody2D player)
	{
		player.Velocity = Vector2.Zero;
		player.GlobalPosition = startPosition.GlobalPosition;
	}
}
