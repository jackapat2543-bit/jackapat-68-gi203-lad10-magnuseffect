using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class TorqueControl : MonoBehaviour
{
    public float torquePower = 0f;
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Keyboard.current.dKey.isPressed)
        {
            _rb.AddTorque(Vector3.right * torquePower);
        }
    }
}
