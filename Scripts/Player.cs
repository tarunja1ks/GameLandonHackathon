using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private int _speed = 300;
    private double miles = 100;

    public override void _Ready()
	{
	}

    public override void _Process(double delta)
	{
	}

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

    public double GetMiles()
    {
        return miles;
    }

    public double AddMiles(double miles)
    {
        this.miles += miles;
        return this.miles;
    }

}