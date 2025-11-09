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
	public int DefaultDamage = 0;

	[Export]
	public float DefaultRange = 0;
	[Export]
	public float DefaultReloadSpeed = 0;
	[Export]
	public int DefaultSpawnBullets = 0;
	[Export]
	public float DefaultBulletSpeed = 0;

	[Export]
	public float DefaultBulletSpread = 0;

	[Export]
	public float DefaultKickback = 0;
	[Export]
	public float DefaultMagaznineSize = 0;


	[Export]
	public Texture2D UITexture = null; // x by y


	[Export(PropertyHint.Range, "0,5,")]
	public int MagaznineSlots = 0;
	[Export(PropertyHint.Range, "0,5,")]
	public int BarrelSlots = 0;
	[Export(PropertyHint.Range, "0,5,")]
	public int GripSlots = 0;
	[Export(PropertyHint.Range, "0,5,")]
	public int StockSlots = 0;

	private int Damage = 0;
	private float Range = 0;
	private float ReloadSpeed = 0;
	private int SpawnBullets = 0;
	private float BulletSpeed = 0;
	private float BulletSpread = 0;
	private float Kickback = 0;

	private float MagaznineSize = 0;




	public Array<NormalAttachment> MagaznineAttachments = new Array<NormalAttachment>();
	public Array<NormalAttachment> BarrelAttachments = new Array<NormalAttachment>();
	public Array<NormalAttachment> GripAttachments = new Array<NormalAttachment>();
	public Array<NormalAttachment> StockAttachments = new Array<NormalAttachment>();
	public override void _Ready()
	{
		MagaznineAttachments.Add(GetNode<NormalAttachment>("NormalAttachment"));
		CalculateAttributes();
	}

	private void CalculateAttributes()
	{
		float DamageMutiplyer = 0;
		float RangeMutiplyer = 0;
		float ReloadSpeedMutiplyer = 0;
		int SpawnBulletsAddition = 0;
		float BulletSpeedMutiplyer = 0;
		float BulletMutiplyer = 0;
		float KickbackMutiplyer = 0;
		int MagaznineSizeAddition = 0;

		foreach (NormalAttachment m in MagaznineAttachments)
		{
			DamageMutiplyer += m.DamagePercentIncrease;
			RangeMutiplyer += m.RangePercentIncrease;
			ReloadSpeedMutiplyer += m.ReloadPercentIncrease;
			SpawnBulletsAddition += m.SpawnBulletsAddition;
			BulletSpeedMutiplyer += m.BulletSpeedPercentIncrease;
			BulletMutiplyer += m.BulletSpreadPercentIncrease;
			KickbackMutiplyer += m.KickbackPercentIncrease;
			MagaznineSizeAddition += m.MagaznineSizeAddition;
		}
		foreach (NormalAttachment m in BarrelAttachments)
		{
			DamageMutiplyer += m.DamagePercentIncrease;
			RangeMutiplyer += m.RangePercentIncrease;
			ReloadSpeedMutiplyer += m.ReloadPercentIncrease;
			SpawnBulletsAddition += m.SpawnBulletsAddition;
			BulletSpeedMutiplyer += m.BulletSpeedPercentIncrease;
			BulletMutiplyer += m.BulletSpreadPercentIncrease;
			KickbackMutiplyer += m.KickbackPercentIncrease;
			MagaznineSizeAddition += m.MagaznineSizeAddition;
		}
		foreach (NormalAttachment m in GripAttachments)
		{
			DamageMutiplyer += m.DamagePercentIncrease;
			RangeMutiplyer += m.RangePercentIncrease;
			ReloadSpeedMutiplyer += m.ReloadPercentIncrease;
			SpawnBulletsAddition += m.SpawnBulletsAddition;
			BulletSpeedMutiplyer += m.BulletSpeedPercentIncrease;
			BulletMutiplyer += m.BulletSpreadPercentIncrease;
			KickbackMutiplyer += m.KickbackPercentIncrease;
			MagaznineSizeAddition += m.MagaznineSizeAddition;
		}
		foreach (NormalAttachment m in StockAttachments)
		{
			DamageMutiplyer += m.DamagePercentIncrease;
			RangeMutiplyer += m.RangePercentIncrease;
			ReloadSpeedMutiplyer += m.ReloadPercentIncrease;
			SpawnBulletsAddition += m.SpawnBulletsAddition;
			BulletSpeedMutiplyer += m.BulletSpeedPercentIncrease;
			BulletMutiplyer += m.BulletSpreadPercentIncrease;
			KickbackMutiplyer += m.KickbackPercentIncrease;
			MagaznineSizeAddition += m.MagaznineSizeAddition;
		}

		Damage = (int)(DefaultDamage * DamageMutiplyer);
		Range = DefaultRange * RangeMutiplyer;
		ReloadSpeed = DefaultReloadSpeed * ReloadSpeedMutiplyer;

		SpawnBullets = DefaultSpawnBullets + SpawnBulletsAddition;
		BulletSpeed = DefaultBulletSpeed * BulletSpeedMutiplyer;
		BulletSpread = DefaultBulletSpread * BulletMutiplyer;
		Kickback = DefaultKickback * KickbackMutiplyer;
		MagaznineSize = DefaultMagaznineSize + MagaznineSizeAddition;
	}
	
	private void ShowAttachmentInformation(Array<NormalAttachment> Attachments, int AttachmentsSlots, String name)
    {
        if (ImGui.CollapsingHeader(name+" - " + AttachmentsSlots))
		{
			int c = 0;

			foreach (NormalAttachment m in Attachments)
			{
				c++;
				if (ImGui.TreeNode(m.AttachmentName))
				{
					m.ShowDebugInformation();
					ImGui.TreePop();
				}
			}
			for(int i = c; i < AttachmentsSlots; i++)
			{
				ImGui.PushID(i);
				ImGui.Button("Drag " + name + " here");
				ImGui.PopID();
            }


		}
    }
	public void ShowDebugInformation()
	{
		ImGui.SeparatorText(WeaponName);
		ImGui.Text("===CURRENT===");
		ImGui.Text("Damage:"  + Damage.ToString());
		ImGui.Text("Range:"  + Range.ToString());
		ImGui.Text("ReloadSpeed:"  + ReloadSpeed.ToString());
		ImGui.Text("SpawnBullets: " + SpawnBullets.ToString());
		ImGui.Text("BulletSpeed: " + BulletSpeed.ToString());
		ImGui.Text("BulletSpread: " + BulletSpread.ToString());
		ImGui.Text("Kickback: " + Kickback.ToString());
		ImGui.Text("MagaznineSize: " + MagaznineSize.ToString());
		
		if (ImGui.Button("Update"))
		{
			CalculateAttributes();
		}

		ImGui.Text("===DEFAULTS===");
		ImGui.Text("DefaultDamage:"  + DefaultDamage.ToString());
		ImGui.Text("DefaultRange:"  + DefaultRange.ToString());
		ImGui.Text("DefaultReloadSpeed:"  + DefaultReloadSpeed.ToString());
		ImGui.Text("DefaultSpawnBullets: " + DefaultSpawnBullets.ToString());
		ImGui.Text("DefaultBulletSpeed: " + DefaultBulletSpeed.ToString());
		ImGui.Text("DefaultBulletSpread: " + DefaultBulletSpread.ToString());
		ImGui.Text("DefaultKickback: " + DefaultKickback.ToString()); 
		ImGui.Text("DefaultMagaznineSize: " + DefaultMagaznineSize.ToString());

		ImGui.Text("===ATTACHMENTS===");
		ShowAttachmentInformation(MagaznineAttachments, MagaznineSlots, "MagaznineAttachments");
		ShowAttachmentInformation(BarrelAttachments, BarrelSlots, "BarrelAttachments");
		ShowAttachmentInformation(GripAttachments,GripSlots,"GripAttachments");
		ShowAttachmentInformation(StockAttachments,StockSlots,"StockAttachments");

	}

}
