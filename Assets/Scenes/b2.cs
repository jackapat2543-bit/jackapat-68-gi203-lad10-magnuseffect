using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class b2 : MonoBehaviour
    
{

    public float enginePower = 20f;
    public float liftBooster = 0.5f;
    public float drag = 0.001f;
    public float angularDrag = 0.001f;

    public float yawPower = 50f;
    public float pitchPower = 50f;
    public float rollPower = 30f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            rb.AddForce(transform.forward * enginePower);

            Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
            rb.AddForce(transform.up * lift.magnitude * liftBooster);

            rb.linearDamping = rb.linearVelocity.magnitude * drag;
            rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;
            var keyboard = Keyboard.current;
            if (keyboard == null) return;

            float yaw = (Keyboard.current.eKey.isPressed ? 1f : 0f) - (Keyboard.current.qKey.isPressed ? 1f : 0f);
            yaw *= yawPower;

            float pitch = (Keyboard.current.wKey.isPressed ? 1f : 0f) - (Keyboard.current.sKey.isPressed ? 1f : 0f);
            pitch *= pitchPower;

            float rool = (Keyboard.current.aKey.isPressed ? 1f : 0f) - (Keyboard.current.dKey.isPressed ? 1f : 0f);
            rollPower *= rollPower;

            rb.AddTorque(transform.up * yaw);
            rb.AddTorque(transform.right * pitch);
            rb.AddTorque(transform.forward * rool);
        } 
        
    }
    private void Update()
    {
       
    }
}
