using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : PhysicsObject {

    public enum Direction
    {
        right,
        left
    }

    public Direction directionMove;
	
	// Update is called once per frame
	void Update () {
        if(directionMove == Direction.left)
        {
            targetVelocity = Vector2.left;
        }
        else
        {
            targetVelocity = Vector2.right;
        }
	}
}
