using Godot;
using System;

public partial class Trap : Node2D
{

	[Signal]
	public delegate void TouchedPlayerEventHandler(player player);
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnBodyEntered(Node body)
	{
		if (body is player)
		{
			var player = (player)body;
			EmitSignal(SignalName.TouchedPlayer, player);
		}
	}
}
