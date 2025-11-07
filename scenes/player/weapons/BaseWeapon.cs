using Godot;
using ImGuiNET;
using System;
using Godot.Collections;

[GlobalClass]
public partial class BaseWeapon : Node
{
	[Export]
	public String WeaponName = "PlaceHolderName";

	[Export]
	public int DefaultSpawnBullets = 0;

	[Export]
	public int NormalAttachmentSlots = 0;

	[Export]
	public int SpecialAttachmentSlots = 0;

	[Export]
	public Texture2D UITexture = null; // x by y

	[Export]
	public bool HasMagaznineSlot = false;

	[Export]
	public bool HasBarrelSlot = false;

	[Export]
	public bool HasGripSlot = false;

	[Export]
	public bool HasStockSlot = false;

	private int SpawnBullets = 0;
	private int BulletSpeed = 0;
	private int BulletSpread = 0;

	
	
	public Array<NormalAttachment> AttachedAttachments = new Array<NormalAttachment>();
	public override void _Ready()
    {
        AttachedAttachments.Add(GetNode<NormalAttachment>("NormalAttachment"));
    }
	public void ShowDebugInformation()
    {
		ImGui.SeparatorText(WeaponName);
		ImGui.Text("DefaultSpawnBullets: " + DefaultSpawnBullets.ToString());
		ImGui.Text("NormalAttachmentSlots: " + NormalAttachmentSlots.ToString());
		ImGui.Text("SpecialAttachmentSlots: " + SpecialAttachmentSlots.ToString());

		foreach (NormalAttachment a in AttachedAttachments)
		{
            if (ImGui.TreeNode(a.AttachmentName))
            {
				a.ShowDebugInformation();
				ImGui.TreePop();
            }
		}
    }
}
