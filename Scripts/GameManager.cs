using Godot;
using System;

public partial class GameManager : Node2D
{
	private Player player;

	private PlayAgain playAgain;
	private RichTextLabel milesText;

	private RichTextLabel maxMilesTest;
	private static System.Timers.Timer aTimer;

	[Export]
	private float gameSpeed = 300f;

	public float minimumGameSpeed = 300f;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNodeOrNull<Player>("Player");
		milesText = GetNodeOrNull<RichTextLabel>("ScoreText");
		maxMilesTest = GetNodeOrNull<RichTextLabel>("HighScore");
		Console.WriteLine(player);
		Console.WriteLine(milesText);

		UpdateMilesText();

		int interval = (int)(5000 - gameSpeed);

		aTimer = new System.Timers.Timer(interval);
		aTimer.Elapsed += OnTimedEvent;
		aTimer.AutoReset = true;
		aTimer.Enabled = true;
	}

	public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
	{
		GD.Print("wtf");
		player.AddMiles(0.5);
		minimumGameSpeed += 5;
		SetGameSpeed(GetGameSpeed() + minimumGameSpeed);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		int interval = (int)(5000 - gameSpeed);

		if (interval < 0)
		{
			interval = 50;
		}

		aTimer.Interval = interval;


		if (player.isDead())
		{
			GetTree().ChangeSceneToFile("res://Scenes/DeathScene.tscn");
		}
		else
		{
			UpdateMilesText();
			UpdateMaxMilesText();
		}

		GD.Print(minimumGameSpeed);

		GD.Print(gameSpeed);

		// if(player.isDead() && playAgain.getPlayAgain()){
		// 	player.AddMiles(-player.GetMiles());
		// 	player.makeAlive();
		// 	GetTree().ChangeSceneToFile("res://Scenes/MainScene.tscn");
		// }
	}

	private void UpdateMilesText()
	{
		milesText.Text = "Miles: " + player.GetMiles();
	}

	private void UpdateMaxMilesText()
	{
		// maxMilesTest.Text="High Score: " + player.getMaxMiles();
		maxMilesTest.Text = "";
	}

	public float GetGameSpeed()
	{
		return gameSpeed;
	}

	public void SetGameSpeed(float speed)
	{
		this.gameSpeed = speed;
	}
}
