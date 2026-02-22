using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private int _speed = 300;
    private double health = 100;

    private RichTextLabel healthText;
    private double miles = 0;

    private double maxmiles=0;

    private double angleDiff = 0;

    private bool Dead=false;

    GameManager manager;

    public override void _Ready()
    {
       this.miles = 0;
       this.manager = GetParent<GameManager>();
    }

    public bool isDead(){
        return Dead; 
    }

    public void makeAlive(){
        Dead=false;
    }

    public void Kill(){
        Dead=true;
    }

    public void GetInput()
    {
        Vector2 steering = Vector2.Zero;
        // GD.Print(angleDiff);
        if(Input.IsActionPressed("MoveLeft",false))
        {
            angleDiff -= 0.04;
            if(angleDiff < -0.5)
            {
                angleDiff = -0.5;
            
            }
            steering = Vector2.Left;
        }
        if(Input.IsActionPressed("MoveRight",false))
        {
            angleDiff += 0.04;
            if(angleDiff > 0.5)
            {
                angleDiff = 0.5;
            }
            steering = Vector2.Right;
        }

        if(Input.IsActionPressed("Accelerate",false))
        {
            manager.SetGameSpeed(manager.GetGameSpeed()+15);
        }

        if(Input.IsActionPressed("Deccelerate",false) && manager.GetGameSpeed() >= 15+manager.minimumGameSpeed)
        {
            manager.SetGameSpeed(manager.GetGameSpeed()-15);
        }
        
        if(angleDiff < 0)
        {
            angleDiff += 0.01;
        }
        if(angleDiff > 0)
        {
            angleDiff -= 0.01;
        }
        this.Rotation = (float)angleDiff;
        Velocity = steering * _speed;
    }

	

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndCollide(Velocity * (float)delta);
        GD.Print(Position);
        if(Position.X > 557 || Position.X < -507)
        {
            Kill();
        }
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


	public void UpdateHealthText()
	{
		// healthText.Text = "Health: " + GetHealth();
        GD.Print("thing");
        healthText=GetNodeOrNull<RichTextLabel>("HealthText");
        healthText.Text = "";
	}

    public double GetMiles()
    {
        return miles;
    }

    public double getMaxMiles(){
        return this.maxmiles;
    }

    public void AddMiles(double miles)
    {
        this.miles += miles;
        this.maxmiles=Math.Max(maxmiles,miles);
    }
}
