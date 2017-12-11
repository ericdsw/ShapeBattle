using Godot;
using System;
using ShapeBattle.Maps;
using ShapeBattle.Characters.Base;

namespace ShapeBattle.Characters.Square
{
    public class SquareBody : BasePlayerBody, IPriorityTarget
    {
        public override void _Input(InputEvent ev)
        {
            if (ev is InputEventMouseButton)
            {
                MoveToPosition(GetGlobalMousePosition());
            }
        }

        public Rect2 GetEnclosingRect()
        {
            Position2D startPoint = GetNode("Boundaries/StartPoint") as Position2D;
            Position2D endPoint = GetNode("Boundaries/EndPoint") as Position2D;

            return new Rect2(startPoint.Position, endPoint.Position);
        }

        public Vector2 GetCenter()
        {
            return Position;
        }
    }
}
