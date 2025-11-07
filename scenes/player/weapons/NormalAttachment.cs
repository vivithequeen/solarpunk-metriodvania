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

	[Export (PropertyHint.Range, "0,1,")]
	public float RangePercentIncrease = 0;
	[Export (PropertyHint.Range, "0,1,")]
	public float ReloadPercentIncrease = 0;
	[Export (PropertyHint.Range, "0,1,")]
	public float DamagePercentIncrease = 0;
	[Export (PropertyHint.Range, "0,1,")]
	public float PrecisionPercentIncrease = 0;
	
	public void ShowDebugInformation()
    {
		ImGui.Text("AttachmentName: " + AttachmentName);
		ImGui.Text("Attachment: " + Attachment.ToString());
		ImGui.Text("RangePercentIncrease: " + RangePercentIncrease.ToString());
		ImGui.Text("ReloadPercentIncrease: " + ReloadPercentIncrease.ToString());
		ImGui.Text("DamagePercentIncrease: " + DamagePercentIncrease.ToString());
		ImGui.Text("PrecisionPercentIncrease: " + PrecisionPercentIncrease.ToString());

    }
}
