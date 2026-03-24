using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class Angular : MonoBehaviour
{
    public float angularSpeed = 0f;

    private Rigidbody _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            _rb.angularVelocity = new Vector3(0, angularSpeed, 0);
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
            
        }
    }
}
