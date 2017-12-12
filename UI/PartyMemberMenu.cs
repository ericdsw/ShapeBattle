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
        AddPartyMemberCommands();
    }

    public void AddPartyMemberButton()
    {
        BattleButton battleButtonInstance = GenerateResource<BattleButton>("res://UI/BattleButton.tscn");
        battleButtonInstance.SetText(PartyMember.Name);
        VBoxContainer.AddChild(battleButtonInstance);
    }

    public void AddPartyMemberCommands()
    {
        GD.Print(PartyMember.Commands.Count);
        foreach (var command in PartyMember.Commands)
        {
            BattleButton battleButton = GenerateResource<BattleButton>("res://UI/BattleButton.tscn");
            battleButton.SetText(command.Name);
            VBoxContainer.AddChild(battleButton);
            VBoxContainer.MoveChild(battleButton, 0);
        }
    }

    //TODO: move to global helper
    public T GenerateResource<T>(String resourceName) where T : Node
    {
        PackedScene scene = ResourceLoader.Load(resourceName) as PackedScene;
        T resource = scene.Instance() as T;
        return resource;
    }
}

