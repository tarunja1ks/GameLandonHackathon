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
	
	public void _on_body_entered(Node2D body){
		if(body is Player){
			body.AddMiles(-100);
		}
	}

	public void _on_input_event(Node viewport, InputEvent @event, int shapeIdx){
		if (@event is InputEventMouseButton mouseButton && mouseButton.ButtonIndex == MouseButton.Left && mouseButton.Pressed)
		{
			SwipeAway();
		}
	}

	private void SwipeAway()
	{
		var tween = CreateTween();
		tween.TweenProperty(this, "position", Position + new Vector2(1000, 0), 0.5f)
			 .SetEase(Tween.EaseType.Out)
			 .SetTrans(Tween.TransitionType.Cubic);
		tween.Finished += () => QueueFree();
	}

	
}
