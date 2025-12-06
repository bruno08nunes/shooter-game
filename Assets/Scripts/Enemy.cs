using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, speed);

        if (transform.position.z > 25)
        {
            gameObject.SetActive(false);
        }
    }
}
