using Godot;
using System;
using Godot.Collections;
using ImGuiGodot;
using ImGuiNET;
using System.Drawing;
using System.Runtime.InteropServices;
[GlobalClass]

public partial class AttachmentHolder : Node
{
    public Array<NormalAttachment> AttachmentInventory = new Array<NormalAttachment>();



    Dictionary d = new Dictionary { { "meow", "meow" } };
    public override void _Ready()
    {
        foreach (NormalAttachment m in GetChildren())
        {
            AttachmentInventory.Add(m);
        }
    }

    public override void _Process(double delta)
    {
        ImGui.Begin("AttachmentInventory");

        foreach (NormalAttachment m in AttachmentInventory)
        {
            if (ImGui.TreeNode(m.AttachmentName))
            {
                m.ShowDebugInformation();
                if (ImGui.BeginDragDropSource())
                {
                    GCHandle handle = GCHandle.Alloc(m, GCHandleType.Pinned);

                    IntPtr ptr = handle.AddrOfPinnedObject();
                    ImGui.SetDragDropPayload("NormalAttachment", ptr, (uint)Marshal.SizeOf<NormalAttachment>());


                    
                    ImGui.EndDragDropSource();

                }
                ImGui.TreePop();
            }

        }
        ImGui.End();
    }
}
