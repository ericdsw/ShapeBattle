using System;
using Godot;
using ShapeBattle.Characters;
using ShapeBattle.Characters.Commands;

namespace ShapeBattle.Characters.Square
{
    public class Square : PartyMember
    {
        public Square()
        {
            Name = "Square";
            MaxHP = 50;
            CurrentHP = 50;

            AddCommand(new MoveCommand());
        }
    }
}
