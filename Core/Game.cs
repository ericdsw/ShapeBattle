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
            ci = (ControllerInput)GetNode("ControllerInput");
            ci.ActionTaken += Ci_ActionTaken;
        }

        public override void _Process(float delta)
        {
            //
        }

        void Ci_ActionTaken(object sender, ControllerInput.ActionTakenEventArgs e)
        {
            switch (e.Action)
            {
                case ControllerInput.Actions.Up:
                    GD.Print("Received signal, up was pressed.");
                    break;
                case ControllerInput.Actions.Down:
                    GD.Print("Received signal, down was pressed.");
                    break;
                case ControllerInput.Actions.Left:
                    GD.Print("Received signal, left was pressed.");
                    break;
                case ControllerInput.Actions.Right:
                    GD.Print("Received signal, right was pressed.");
                    break;
                case ControllerInput.Actions.Accept:
                    GD.Print("Received signal, accept was pressed.");
                    break;
                case ControllerInput.Actions.Cancel:
                    GD.Print("Received signal, cancel was pressed.");
                    break;
                case ControllerInput.Actions.Click:
                    GD.Print("Received signal, click was pressed.");
                    break;
                default:
                    // Nothing is being pressed
                    break;
            }
        }
    }
}
