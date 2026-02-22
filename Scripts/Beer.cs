using Godot;
using System;

public partial class Beer : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _on_body_entered(Node2d body){
		if(body is Player){
			body.TakeDamage(10);
		}
	}
	public override void _on_mouse_entered(){
		// make the beer bottle cancel
	}
	
}
