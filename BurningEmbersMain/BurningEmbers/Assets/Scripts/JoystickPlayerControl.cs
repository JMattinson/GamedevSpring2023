using UnityEngine;

public class JoystickPlayerControl : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        //Whoever coded Unity's new input system should be tried as a warcriminal.
        Vector3 movementDirection = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
        movementDirection.Normalize();
        transform.Translate(movementDirection * (speed * Time.deltaTime),Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,rotateSpeed * Time.deltaTime);
        }
    }
}