using Godot;
using System;
using ImGuiGodot;
using ImGuiNET;
[GlobalClass]
public partial class NormalAttachment : Node
{
	public enum AttachmentTypes
	{
		Magaznine,
		Barrel,
		Grip,
		Stock,
	}

	[Export]
	public String AttachmentName;
	[Export]
	public AttachmentTypes Attachment;

	[Export(PropertyHint.Range, "0,2,")]
	public float DamagePercentIncrease = 1;

	[Export(PropertyHint.Range, "0,2,")]
	public float RangePercentIncrease = 1;
	
	[Export (PropertyHint.Range, "0,2,")]
	public float ReloadPercentIncrease = 1;

	[Export(PropertyHint.Range, "-10, 10,")]
	public int SpawnBulletsAddition = 0;

	[Export(PropertyHint.Range, "0,2,")]
	public float BulletSpeedPercentIncrease = 1;

	[Export(PropertyHint.Range, "0,2,")]
	public float BulletSpreadPercentIncrease = 1;

	[Export(PropertyHint.Range, "0,2,")]
	public float KickbackPercentIncrease = 1;

	[Export(PropertyHint.Range, "-10,10,")]
	public int MagaznineSizeAddition;
	
	public void ShowDebugInformation()
	{
		ImGui.Text("AttachmentName: " + AttachmentName);

		ImGui.Text("Attachment: " + Attachment.ToString());
		ImGui.Text("RangePercentIncrease: " + (RangePercentIncrease*100).ToString() + "%%");
		ImGui.Text("ReloadPercentIncrease: " + (ReloadPercentIncrease*100).ToString() + "%%");
		ImGui.Text("DamagePercentIncrease: " + (DamagePercentIncrease*100).ToString() + "%%");
		ImGui.Text("SpawnBulletsAddition: " + SpawnBulletsAddition.ToString());

		ImGui.Text("BulletSpeedPercentIncrease: " + (BulletSpeedPercentIncrease*100).ToString() + "%%");
		ImGui.Text("BulletSpreadPercentIncrease: " + (BulletSpreadPercentIncrease*100).ToString() + "%%");
		ImGui.Text("KickbackPercentIncrease: " + (KickbackPercentIncrease * 100).ToString() + "%%");
		ImGui.Text("MagaznineSizeAddition: " + MagaznineSizeAddition.ToString());

	}
}
