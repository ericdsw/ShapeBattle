using Godot;
using System;

public class ControllerInput : Node
{	

    public override void _Ready()
    {
		
    }
	
	public override void _Input(InputEvent ev)
	{
		if (ev is InputEventKey)
		{
			InputEventKey keyEvent = (InputEventKey) ev;
			
			if (keyEvent.IsActionPressed("ui_up"))
			{
				GD.Print("pressed up");
				// send signal
			} else if (keyEvent.IsActionPressed("ui_down"))
			{
				GD.Print("pressed down");
				// send signal
			} else if (keyEvent.IsActionPressed("ui_left"))
			{
				GD.Print("pressed left");
				// send signal
			} else if (keyEvent.IsActionPressed("ui_right"))
			{
				GD.Print("pressed right");
				// send signal
			} else if (keyEvent.IsActionPressed("ui_accept"))
			{
				GD.Print("pressed accept");
				// send signal
			} else if (keyEvent.IsActionPressed("ui_cancel"))
			{
				GD.Print("pressed cancel");
				// send signal
			}
		} else if (ev is InputEventMouse)
		{
			InputEventMouse mouseEvent = (InputEventMouse) ev;
			
			if (mouseEvent.IsActionPressed("mouse_accept"))
			{
				GD.Print("clicked accept");
				// send signal
			}
		}
	}
}
