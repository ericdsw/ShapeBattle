using Godot;
using System;

namespace ShapeBattle.Maps 
{    
    public class CameraContainer : Node2D
    {
        // Internal variables
        private IPriorityTarget _priorityTarget;
        private Rect2 _cameraRect;
        private Node2D[] _followTargets = { };

        // Nodes
        private Node2D _viewport;
        private Camera2D _camera;

        public override void _Ready()
        {
            _viewport = (Node2D)GetNode("Viewport");
            _camera   = (Camera2D)GetNode("Camera");
        }

        public override void _PhysicsProcess(float delta)
        {
            if (_priorityTarget != null)
            {
                Vector2 mediumPoint = _priorityTarget.GetCenter();

                foreach (Node2D followTarget in _followTargets)
                {
                    mediumPoint = (mediumPoint + followTarget.Position) / 2;
                }

                Rect2 cameraRect = _GenerateCameraViewportRect(mediumPoint);

                if (_cameraRect.Encloses(_priorityTarget.GetEnclosingRect()))
                {
                    Vector2 startOffset = _GetOutsideStartMovement(cameraRect);
                    Vector2 endOffset   = _GetOutsideEndMovement(cameraRect);
                    mediumPoint += startOffset + endOffset;
                }

                GlobalPosition = mediumPoint;
            }
        }

        public void Follow(IPriorityTarget target)
        {
            _priorityTarget = target;
        }

        public void Follow(IPriorityTarget target, Node2D[] additionalTargets)
        {
            _priorityTarget = target;
            _followTargets  = additionalTargets;
        }

        public void ShowInViewport(Node2D element)
        {
            _viewport.AddChild(element);
        }

        private Rect2 _GenerateCameraViewportRect(Vector2 centerPoint)
        {
            Vector2 viewportPosition = GetViewportRect().Position;
            Vector2 viewportSize = GetViewportRect().Size;

            return new Rect2(
                    viewportPosition.x + centerPoint.x - viewportSize.x * (_camera.Zoom.x / 2),
                    viewportPosition.y + centerPoint.y - viewportSize.y * (_camera.Zoom.y / 2),
                    viewportSize.x * _camera.Zoom.x,
                    viewportSize.y * _camera.Zoom.y
            );
        }

        private Vector2 _GetOutsideStartMovement(Rect2 enclosingRect)
        {
            Vector2 Difference = enclosingRect.Position - _priorityTarget.GetEnclosingRect().Position;
            Vector2 Movement = new Vector2(0, 0);
            if (Difference.x > 0) { Movement.x -= Difference.x; }
            if (Difference.y > 0) { Movement.y -= Difference.y; }
            return Movement;
        }

        private Vector2 _GetOutsideEndMovement(Rect2 enclosingRect)
        {
            Vector2 Difference = enclosingRect.End - _priorityTarget.GetEnclosingRect().End;
            Vector2 Movement = new Vector2(0, 0);
            if (Difference.x < 0) { Movement.x -= Difference.x; }
            if (Difference.y < 0) { Movement.y -= Difference.y; }
            return Movement;
        }
    }
}