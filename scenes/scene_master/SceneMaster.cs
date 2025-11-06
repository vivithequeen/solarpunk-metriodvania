using Godot;
using System;
using ImGuiGodot;
using ImGuiNET;
public partial class SceneMaster : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {

		ImGui.BeginMainMenuBar();
		ImGui.Text("fps: " + Engine.GetFramesPerSecond().ToString());
		ImGui.EndMainMenuBar();


		
    }
}
