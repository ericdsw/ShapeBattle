using Godot;
using System;
using ShapeBattle.Maps;

namespace ShapeBattle.Core 
{    
    public class Game : Node
    {
        private ControllerInput ci;

        public override void _Ready()
        {
            GD.Print("I'm alive!");
        }

        public override void _Process(float delta)
        {
            //
        }
    }
}
