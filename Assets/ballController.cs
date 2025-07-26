using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    Rigidbody2D rb;
    int[] direction = { -1, 1 };
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Debug.Log(direction[Random.Range(0, 2)]);
        rb.AddForce(new Vector2(100f * direction[Random.Range(0, 2)], Random.Range(80,100)) * 2);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.magnitude > 10) return;
        rb.velocity *= 1.05f;
    }
    // Update is called once per frame
    void Update()
    {
        while(rb.velocity.magnitude < 3)
        {
            rb.velocity += rb.velocity * 0.5f;
        }
        if (transform.position.x < -10 || transform.position.x > 10) Destroy(gameObject);
    }
}
