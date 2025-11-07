using Godot;
using ImGuiNET;
using System;

public partial class WeaponManager : Node
{
	[Export]
	BaseWeapon[] CurrentWeapons;
	// Called when the node enters the scene tree for the first time.


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
		ShowCurrentWeaponsDebug();
    }

	public void ShowCurrentWeaponsDebug()
	{
		foreach (BaseWeapon a in CurrentWeapons)
		{
			ImGui.Begin("Current Weapon Debug");
			a.ShowDebugInformation();
			ImGui.End();
		}
	}
}
