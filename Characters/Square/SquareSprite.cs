using System;
using Godot;

namespace ShapeBattle.Characters.Square
{
    public class SquareSprite : Sprite
    {
        [Export]
        float RotationSpeed = 30.0f;

        public override void _PhysicsProcess(float delta)
        {
            RotationDegrees += RotationSpeed * delta;
        }
    }
}
