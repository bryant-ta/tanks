using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition((Vector2)transform.position + dir * speed * 10 * Time.fixedDeltaTime);
    }
}