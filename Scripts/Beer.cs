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
	
	public void _on_body_entered(Node2d body){
		if(body is Player){
			body.TakeDamage(10);
		}
	}

	public void _on_input_event(Node viewport, InputEvent @event, int shapeIdx){
		if (@event is InputEventMouseButton mouseButton && mouseButton.ButtonIndex == MouseButton.Left && mouseButton.Pressed && _isHovered)
		{
			SwipeAway();
		}
	}

	private void SwipeAway()
	{
		GD.Print("Swiping away: " + Name);
		// You can use a Tween for a smooth animation
		var tween = CreateTween();
		tween.TweenProperty(this, "position", Position + new Vector2(1000, 0), 0.5f)
			 .SetEase(Tween.EaseType.Out)
			 .SetTrans(Tween.TransitionType.Cubic);
		tween.Finished += () => QueueFree();
	}

	
}
