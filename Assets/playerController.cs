using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// y: -5~5±îÁö 
public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (rb.velocity.y < 0) rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, 5.0f) * 10);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (rb.velocity.y > 0) rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, -5.0f) * 10);
        }
    }
}
