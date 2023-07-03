using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Rigidbody2D rigid;
    public KeyInput InputManager;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        AddMyself2InputManager();
    }
    public void AddMyself2InputManager()
    {
        InputManager.AddToObjects(gameObject);
    }

    public void setVelocity(Vector2 Velocity)
    {
        rigid.velocity = Velocity;
    }
}
