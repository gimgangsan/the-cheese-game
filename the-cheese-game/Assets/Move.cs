using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public Vector2 inputVec;
    public float speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.AddForce(nextVec);
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    // Update is called once per frame

}
