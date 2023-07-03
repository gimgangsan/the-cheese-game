using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Move : MovingObject
{
    // Start is called before the first frame update
    private Vector2 inputVec;

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec;
        rigid.velocity = nextVec;
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    // Update is called once per frame

}
