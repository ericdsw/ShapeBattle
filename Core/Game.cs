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
            ci.KeyPressed += Ci_KeyPressed;
        }

        public override void _Process(float delta)
        {
            //
        }

        void Ci_KeyPressed(object sender, ControllerInput.KeyPressedEventArgs e)
        {
            switch (e.Action)
            {
                case ControllerInput.Keys.Up:
                    GD.Print("Received signal, up was pressed.");
                    break;
                case ControllerInput.Keys.Down:
                    GD.Print("Received signal, down was pressed.");
                    break;
                case ControllerInput.Keys.Left:
                    GD.Print("Received signal, left was pressed.");
                    break;
                case ControllerInput.Keys.Right:
                    GD.Print("Received signal, right was pressed.");
                    break;
                case ControllerInput.Keys.Accept:
                    GD.Print("Received signal, accept was pressed.");
                    break;
                case ControllerInput.Keys.Cancel:
                    GD.Print("Received signal, cancel was pressed.");
                    break;
                case ControllerInput.Keys.Click:
                    GD.Print("Received signal, click was pressed.");
                    break;
                default:
                    // Nothing is being pressed
                    break;
            }
        }
    }
}
