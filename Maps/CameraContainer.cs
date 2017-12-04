using Godot;
using System;

public class CameraContainer : Node2D
{
    private CameraPriorityTarget _PriorityTarget;
    private Node2D[] _FollowTargets;
    private Rect2 _CameraRect;

    private Node2D _Viewport;
	private Camera2D _Camera;

    public override void _Ready()
    {
        _Viewport = (Node2D) GetNode("Viewport");
		_Camera = (Camera2D) GetNode("Camera");
    }

    public override void _PhysicsProcess(float delta)
    {
        if (_PriorityTarget != null) 
        {
            Vector2 MediumPoint = _PriorityTarget.GetPosition();

            foreach (Node2D followTarget in _FollowTargets)
            {
                MediumPoint = (MediumPoint + followTarget.Position) / 2;
            }

            Rect2 CameraRect = _GenerateCameraViewportRect(MediumPoint);

            if (_CameraRect.Encloses(_PriorityTarget.GetEnclosingRect()))
            {
                Vector2 StartOffset = _GetOutsideStartMovement(CameraRect);
                Vector2 EndOffset   = _GetOutsideEndMovement(CameraRect);
                MediumPoint += StartOffset + EndOffset;
            }

            GlobalPosition = MediumPoint;
        }
    }
	
	public void Follow(CameraPriorityTarget target)
	{
		_PriorityTarget = target;
	}

    public void Follow(CameraPriorityTarget target, Node2D[] additionalTargets)
    {
        _PriorityTarget = target;
        _FollowTargets = additionalTargets;
    }

    public void ShowInViewport(Node element)
    {
        _Viewport.AddChild(element);
    }

    private Rect2 _GenerateCameraViewportRect(Vector2 centerPoint)
    {
        Vector2 ViewportPosition = GetViewportRect().Position;
        Vector2 ViewportSize     = GetViewportRect().Size;

        return new Rect2(
                ViewportPosition.x + centerPoint.x - ViewportSize.x * (_Camera.Zoom.x / 2),
                ViewportPosition.y + centerPoint.y - ViewportSize.y * (_Camera.Zoom.y / 2),
                ViewportSize.x * _Camera.Zoom.x,
                ViewportSize.y * _Camera.Zoom.y
        );
    }

    private Vector2 _GetOutsideStartMovement(Rect2 enclosingRect)
    {
        Vector2 Difference = enclosingRect.Position - _PriorityTarget.GetEnclosingRect().Position;
        Vector2 Movement   = new Vector2(0,0);
        if (Difference.x > 0) { Movement.x -= Difference.x; }
        if (Difference.y > 0) { Movement.y -= Difference.y; }
        return Movement;
    }

    private Vector2 _GetOutsideEndMovement(Rect2 enclosingRect)
    {
        Vector2 Difference = enclosingRect.End - _PriorityTarget.GetEnclosingRect().End;
        Vector2 Movement   = new Vector2(0,0);
        if (Difference.x < 0) { Movement.x -= Difference.x; }
        if (Difference.y < 0) { Movement.y -= Difference.y; }
        return Movement;
    }
}
