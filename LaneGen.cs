using Godot;
using System;

public partial class LaneGen : Node2D
{
    [Export]
    public int maxLanes = 5;

    public double laneWidth = 350;

    Node2D skibidi;

    bool hasLoadedRoad = false;
    private GameManager gameManager;


    public override void _Ready()
    {
        this.gameManager = (GameManager)GetParent();
    //    loadRoad();
    }
    
    public void loadRoad()
    {
        PackedScene road = GD.Load<PackedScene>("res://Assets/Prefab/lane.tscn");
       skibidi = (Node2D)road.Instantiate();
       skibidi.GlobalPosition = new Vector2(this.GlobalPosition.X,-679);
       this.GetParent().CallDeferred("add_child", skibidi);
    }


    public override void _Process(double delta)
    {
        this.Translate(Vector2.Down * gameManager.GetGameSpeed() * (float)delta);
        if(!hasLoadedRoad && this.GlobalPosition.Y > -78)
        {
            hasLoadedRoad = true; 
            loadRoad();
        }
        if(this.GlobalPosition.Y > 726)
        {
            this.QueueFree();
        }
    }


    // public 


}
