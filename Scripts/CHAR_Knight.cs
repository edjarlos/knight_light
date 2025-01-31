using Godot;
using System;

public partial class CHAR_Knight : CharacterBody2D
{
	public const float Speed = 500f;
	public const float jumpVelocity = -500f;
	public const float gravity = 500f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 vel = Velocity;

		if(!IsOnFloor()){
			vel.Y += gravity * (float)delta;
		}

		if(Input.IsActionJustPressed("Jump") && IsOnFloor()){
			vel.Y = jumpVelocity;
		} else if(Input.IsActionJustReleased("Jump") && vel.Y < 0){
			vel.Y = vel.Y/2;
		}

		if(Input.IsActionPressed("Left")){
			vel.X = -Speed;
		} else if(Input.IsActionPressed("Right")){
			vel.X = Speed;
		} else{
			vel.X = 0;
		}

		Velocity = vel;
		MoveAndSlide();
	}

}
