using System;
using Godot;

public interface CameraPriorityTarget
{
    Rect2 GetEnclosingRect();
    Vector2 GetPosition();
}
