using Godot;
using ImGuiNET;
using System;

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

	private int SpawnBullets = 0;
	private int BulletSpeed = 0;
	private int BulletSpread = 0;
	
	[Export]
	NormalAttachment[] AttachedAttachments;
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
