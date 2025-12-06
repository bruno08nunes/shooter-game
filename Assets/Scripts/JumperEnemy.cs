using UnityEngine;

// INHERITANCE
public class JumperEnemy : Enemy
{
    [SerializeField] float jumpSpeed = 5;
    float yInitialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        yInitialPosition = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    // POLYMORPHISM
    protected override void Move()
    {
        if (transform.position.y <= yInitialPosition + 0.5f)
        {
            Debug.Log(yInitialPosition);
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        base.Move();
    }
}
