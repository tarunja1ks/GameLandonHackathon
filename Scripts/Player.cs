using Godot;
using System;

public partial class Player : CharacterBody2D
{
<<<<<<< HEAD
	private int _speed = 300;

	public void GetInput()
	{
		Vector2 inputDir = Input.GetVector("MoveLeft", "MoveRight", "null", "null");
		Velocity = inputDir * _speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndCollide(Velocity * (float)delta);
	}
}
=======
    private int _speed = 300;
    private double health = 100;

    public void GetInput()
    {
        // Vector2 inputDir = Input.GetVector("MoveLeft", "MoveRight", "null", "null");
        // Input.ge
        Vector2 direction = Vector2.Zero;
        if(Input.IsActionJustPressed("MoveLeft"))
        {
            direction = Vector2.Left;
        }

        if(Input.IsActionJustPressed("MoveRight"))
        {
            direction = Vector2.Right;
        }
        
        Velocity = direction * _speed;
    }

    

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        // MoveAndCollide(Velocity * (float)delta);
    }

    public double GetHealth()
    {
        return health;
    }

    public double TakeDamage(double damage)
    {
        health -= damage;
        return health;
    }
}
>>>>>>> refs/remotes/origin/main
