using Godot;
using ImGuiNET;
using System;
using Godot.Collections;

public partial class WeaponManager : Node
{
	
	Array<BaseWeapon> CurrentWeapons = new Array<BaseWeapon>();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		var baseWeapon = GetNode<BaseWeapon>("BaseWeapon");
		if (baseWeapon != null)
		{
			CurrentWeapons.Add(baseWeapon);
		}
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void _Process(double delta)
    {
		ShowCurrentWeaponsDebug();
    }

	public void ShowCurrentWeaponsDebug()
	{
		ImGui.Begin("Current Weapon Debug");
		

		foreach (BaseWeapon weapon in CurrentWeapons)
		{
			if (weapon != null)
			{
				weapon.ShowDebugInformation();
			}
		}
		
		ImGui.End();
	}
}
