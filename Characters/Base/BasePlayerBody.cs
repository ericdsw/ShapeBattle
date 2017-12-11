using System;
using Godot;

namespace ShapeBattle.Characters.Base
{
    public class BasePlayerBody : KinematicBody2D
    {
        [Export]
        public float MovementSpeed = 200;

        private Vector2? _targetPosition;

        public void MoveToPosition(Vector2 position)
        {
            _targetPosition = position;
        }

        public override void _PhysicsProcess(float delta)
        {
            if (_targetPosition.HasValue)
            {

                if (Position.DistanceTo(_targetPosition.Value) > 5)
                {
                    Vector2 direction = (_targetPosition.Value - Position).Normalized();
                    Vector2 motion = direction * MovementSpeed * delta;

                    Position += motion;
                }
                else
                {
                    Position = _targetPosition.Value;
                    _targetPosition = null;
                }
            }
        }
    }
}
