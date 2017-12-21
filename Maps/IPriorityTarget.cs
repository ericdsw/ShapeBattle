using Godot;

namespace ShapeBattle.Maps
{
    public interface IPriorityTarget
    {
        Rect2 GetEnclosingRect();
        Vector2 GetCenter();
    }
}
