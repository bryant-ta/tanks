using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float accel = 2;
    [Range(0,100)]
    public float maxSpeed;          // 100 is fastest
    public float turnAccel = 2;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = (100 - maxSpeed) / 10 + 1;
    }

    private void FixedUpdate()
    {
        //Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //rb.MovePosition((Vector2)transform.position + dir * speed * 10 * Time.fixedDeltaTime);

        float drive = Input.GetAxisRaw("Vertical");     // driving
        float turn = Input.GetAxisRaw("Horizontal");    // steering

        // Driving
        Vector2 curSpeed = transform.right * drive * accel * 10;
        rb.AddForce(curSpeed);                          // Max speed done in inspector "Linear Drag"

        // Steering

        rb.MoveRotation(transform.rotation. turn * turnAccel * 10);
        print(turn * turnAccel * 10);
    }
}