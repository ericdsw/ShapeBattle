using Godot;
using System;
using ShapeBattle.Maps;

namespace ShapeBattle.Characters.Square
{
    public class Square : KinematicBody2D, IPriorityTarget
    {
        private CollisionShape2D collisionShape;

        public override void _Ready()
        {
            collisionShape = (CollisionShape2D) GetNode("CollisionShape");
        }

        public Rect2 GetEnclosingRect()
        {
            return new Rect2(-20, -20, 20, 20);
        }

        public Vector2 GetCenter()
        {
            return Position;
        }
    }
}
