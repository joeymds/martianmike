using Godot;
using System;

public partial class level : Node2D
{
	public override void _Ready()
	{
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
}
