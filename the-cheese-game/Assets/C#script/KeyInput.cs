using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class KeyInput : MonoBehaviour
{
    public PlayerInput PlayerInput;
    public Vector2 Input;
    public List<GameObject> Objects;

    public abstract void MoveAllObject();
    public abstract void AddToObjects(GameObject NewObject);

}
