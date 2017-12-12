using Godot;
using System;
using ShapeBattle.Characters;
using ShapeBattle.UI;

public class PartyMemberMenu : Node2D
{
    public PartyMember PartyMember;
    VBoxContainer VBoxContainer;

    public override void _Ready()
    {
        VBoxContainer = GetNode("VBoxContainer") as VBoxContainer;

        AddPartyMemberButton();
    }

    public void AddPartyMemberButton()
    {
        var battleButtonResource = ResourceLoader.Load("src://UI/BattleButton.tscn") as PackedScene;
        var battleButtonInstance = battleButtonResource.Instance() as BattleButton;

        VBoxContainer.AddChild(battleButtonInstance);
    }
}
