using Godot;
using System;

public class ControllerInput : Node
{
    public enum Actions { Up, Down, Left, Right, Accept, Cancel, Click, None };
    public event EventHandler<ActionTakenEventArgs> ActionTaken;

    public class ActionTakenEventArgs : EventArgs
    {
        private Actions _action;
        public Actions Action
        {
            get => _action;
            set => _action = value;
        }

        public ActionTakenEventArgs(Actions action)
        {
            this._action = action;
        }
    }

    public override void _Ready()
    {
		
    }
	
    public override void _Input(InputEvent ev)
	{
        Actions action = Actions.None;
        if (ev is InputEventKey keyEvent)
        {
            if (keyEvent.IsActionPressed("ui_up"))
            {
                action = Actions.Up;
            }
            else if (keyEvent.IsActionPressed("ui_down"))
            {
                action = Actions.Down;
            }
            else if (keyEvent.IsActionPressed("ui_left"))
            {
                action = Actions.Left;
            }
            else if (keyEvent.IsActionPressed("ui_right"))
            {
                action = Actions.Right;
            }
            else if (keyEvent.IsActionPressed("ui_accept"))
            {
                action = Actions.Accept;
            }
            else if (keyEvent.IsActionPressed("ui_cancel"))
            {
                action = Actions.Cancel;
            }
        }
        else if (ev is InputEventMouse mouseEvent)
        {
            if (mouseEvent.IsActionPressed("mouse_accept"))
            {
                action = Actions.Click;
            }
        }

        if (action != Actions.None)
        {
            OnActionTaken(new ActionTakenEventArgs(action));
        }
    }

    protected virtual void OnActionTaken(ActionTakenEventArgs eventArgs)
    {
        ActionTaken?.Invoke(this, eventArgs);
    }
}
