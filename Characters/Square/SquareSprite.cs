using System;
using Godot;

namespace ShapeBattle.Characters.Square
{
    public class SquareSprite : Sprite
    {
        [Export]
        float rotationSpeed = 3.0f;


        public override void _PhysicsProcess(float delta)
        {
            Rotation += rotationSpeed * delta;
        }
    }
}
