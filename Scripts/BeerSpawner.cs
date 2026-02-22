using Godot;
using System;

public partial class BeerSpawner : Timer
{
    [Export]
    public PackedScene BeerScene { get; set; }

	private double beerLeftMost   = -500;
	private double beerRightMost  = 500;
	private double beerTopMost    = -340;
	private double beerBottomMost = 726;
	private GameManager gameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.gameManager = (GameManager)GetParent();
		this.WaitTime = 0.67f;
		this.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnTimeout()
	{
		Vector2 spawnPosition = new Vector2(
			(float) GD.RandRange(beerLeftMost, beerRightMost),
			(float) GD.RandRange(beerTopMost, beerBottomMost)
		);
		Beer beer = (Beer)BeerScene.Instantiate<Node2D>();
		beer.ZIndex = 5;
		beer.Position = spawnPosition;
		this.gameManager.AddChild(beer);
	}
}
