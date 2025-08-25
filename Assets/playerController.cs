using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (rb.velocity.y >= 7) rb.velocity += rb.velocity * 0.09f;
            else
            {
                rb.velocity += new Vector2(0, 3f);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (rb.velocity.y <= -7) rb.velocity += rb.velocity * 0.05f;
            else rb.velocity += new Vector2(0, -3.0f);
        }
        else rb.velocity = rb.velocity * 0.95f;
    }
}
