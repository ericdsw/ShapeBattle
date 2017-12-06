using Godot;
using System;

namespace ShapeBattle.Maps 
{    
    public class CameraContainer : Node2D
    {
        // Internal variables
        private IPriorityTarget priorityTarget;
        private Rect2 cameraRect;
        private Node2D[] followTargets = { };

        // Nodes
        private Node2D viewport;
        private Camera2D camera;

        public override void _Ready()
        {
            viewport = (Node2D) GetNode("Viewport");
            camera   = (Camera2D) GetNode("Camera");
        }

        public override void _PhysicsProcess(float delta)
        {
            if (priorityTarget != null)
            {
                Vector2 mediumPoint = priorityTarget.GetCenter();

                foreach (Node2D followTarget in followTargets)
                {
                    mediumPoint = (mediumPoint + followTarget.Position) / 2;
                }

                Rect2 CameraRect = _GenerateCameraViewportRect(mediumPoint);

                if (cameraRect.Encloses(priorityTarget.GetEnclosingRect()))
                {
                    Vector2 StartOffset = _GetOutsideStartMovement(CameraRect);
                    Vector2 EndOffset   = _GetOutsideEndMovement(CameraRect);
                    mediumPoint += StartOffset + EndOffset;
                }

                GlobalPosition = mediumPoint;
            }
        }

        public void Follow(IPriorityTarget target)
        {
            priorityTarget = target;
        }

        public void Follow(IPriorityTarget target, Node2D[] additionalTargets)
        {
            priorityTarget = target;
            followTargets  = additionalTargets;
        }

        public void ShowInViewport(Node2D element)
        {
            viewport.AddChild(element);
        }

        private Rect2 _GenerateCameraViewportRect(Vector2 centerPoint)
        {
            Vector2 ViewportPosition = GetViewportRect().Position;
            Vector2 ViewportSize = GetViewportRect().Size;

            return new Rect2(
                    ViewportPosition.x + centerPoint.x - ViewportSize.x * (camera.Zoom.x / 2),
                    ViewportPosition.y + centerPoint.y - ViewportSize.y * (camera.Zoom.y / 2),
                    ViewportSize.x * camera.Zoom.x,
                    ViewportSize.y * camera.Zoom.y
            );
        }

        private Vector2 _GetOutsideStartMovement(Rect2 enclosingRect)
        {
            Vector2 Difference = enclosingRect.Position - priorityTarget.GetEnclosingRect().Position;
            Vector2 Movement = new Vector2(0, 0);
            if (Difference.x > 0) { Movement.x -= Difference.x; }
            if (Difference.y > 0) { Movement.y -= Difference.y; }
            return Movement;
        }

        private Vector2 _GetOutsideEndMovement(Rect2 enclosingRect)
        {
            Vector2 Difference = enclosingRect.End - priorityTarget.GetEnclosingRect().End;
            Vector2 Movement = new Vector2(0, 0);
            if (Difference.x < 0) { Movement.x -= Difference.x; }
            if (Difference.y < 0) { Movement.y -= Difference.y; }
            return Movement;
        }
    }
}