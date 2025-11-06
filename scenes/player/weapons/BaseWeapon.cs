using Godot;
using ImGuiNET;
using System;

[GlobalClass]
public partial class BaseWeapon : Node
{
	[Export]
	public String WeaponName = "PlaceHolderName";

	[Export]
	public int DefaultSpawnBullets;

	[Export]
	public int NormalAttachmentSlots;

	[Export]
	public int SpecialAttachmentSlots;

	[Export]
	public Texture2D UITexture; // x by y

	private int SpawnBullets;
	private int BulletSpeed;
	private int BulletSpread;
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	public void ShowDebugInformation()
    {
		ImGui.SeparatorText(WeaponName);
		ImGui.Text("DefaultSpawnBullets: " + DefaultSpawnBullets.ToString());
		ImGui.Text("NormalAttachmentSlots: " + NormalAttachmentSlots.ToString());
		ImGui.Text("SpecialAttachmentSlots: " + SpecialAttachmentSlots.ToString());

    }
}
