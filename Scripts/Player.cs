using Godot;
using System;

public partial class Player : Node2D
{
    private int _speed = 300;
    private double health = 100;
    private double miles = 0;

    private bool Dead=false;

    CharacterBody2D character;

    public override void _Ready()
    {
       this.character = GetNode<CharacterBody2D>("CharacterBody2D");
       this.miles = 0;
    }

    public bool isDead(){
        return Dead; 
    }

    public void Kill(){
        Dead=true;
    }


    public void GetInput()
    {
        Vector2 steering = Vector2.Zero;
        if(Input.IsActionPressed("MoveLeft",false))
        {
            steering = Vector2.Left;
        }
        if(Input.IsActionPressed("MoveRight",false))
        {
            steering = Vector2.Right;
        }
        
        character.Velocity = steering * _speed;
    }

	

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        character.MoveAndCollide(character.Velocity * (float)delta);
    }

	public double GetHealth()
	{
		return health;
	}

	public double TakeDamage(double damage)
	{
		health -= damage;
		UpdateHealthText();
		return health;
	}


	private void UpdateHealthText()
	{
		// healthText.Text = "Health: " + GetHealth();
	}

    public double GetMiles()
    {
        return miles;
    }

    public void AddMiles(double miles)
    {
        this.miles += miles;
    }
}
