using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        Vector3 rotation = new(0, 0, GetRotationInput() * rotationSpeed);
        transform.Rotate(-rotation);
    }

    private void Move()
    {
        Vector2 dir = new Vector2(GetMoveInput(), 0);
        Vector2 move = transform.TransformDirection(dir);
        move *= moveSpeed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + move);
    }

    private float GetRotationInput() => Input.GetAxis("Horizontal");

    private float GetMoveInput() => Input.GetAxis("Vertical");
}
