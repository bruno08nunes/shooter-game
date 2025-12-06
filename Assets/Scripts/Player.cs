using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5;
    [SerializeField] float shotDelay = 0.5f;
    float lastShotTime = 0;

    ObjectPool shotPooling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shotPooling = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    void MovePlayer()
    {
        float input = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector3(
           rb.linearVelocity.x,
           rb.linearVelocity.y,
           input * speed
       );
    }

    void Shoot()
    {
        if (Time.realtimeSinceStartup - lastShotTime < shotDelay && lastShotTime != 0)
        {
            return;
        }

        GameObject shot = shotPooling.GetPooledObject();
        if (shot is null)
        {
            return;
        }

        shot.transform.position = transform.position + new Vector3(-1, 0, 0);
        shot.transform.SetParent(gameObject.transform);
        shot.SetActive(true);
        lastShotTime = Time.realtimeSinceStartup;
    }
}
