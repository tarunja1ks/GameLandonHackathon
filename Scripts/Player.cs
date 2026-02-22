using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private int _speed = 300;
    private double health = 100;

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