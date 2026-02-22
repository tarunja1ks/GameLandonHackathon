using Godot;
using System;

public partial class GameManager : Node2D
{
	private Player player;

	private PlayAgain playAgain;
	private RichTextLabel milesText;
	private static System.Timers.Timer aTimer;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNodeOrNull<Player>("Player");
		milesText = GetNodeOrNull<RichTextLabel>("ScoreText");
		Console.WriteLine(player);
		Console.WriteLine(milesText);

		UpdateMilesText();

		aTimer = new System.Timers.Timer(2000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
	}

	public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        player.AddMiles(0.5);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(player.isDead()){
			GetTree().ChangeSceneToFile("res://Scenes/DeathScene.tscn");
		}
		else{
			UpdateMilesText();
		}

		if(player.isDead() && playAgain.getPlayAgain()){
			player.AddMiles(-player.GetMiles());
			player.makeAlive();
			GetTree().ChangeSceneToFile("res://Scenes/MainScene.tscn");

		}
	}

	private void UpdateMilesText()
    {
        milesText.Text = "Miles: " + player.GetMiles();
    }

}
