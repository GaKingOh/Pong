using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 똑똑한 버젼이다. 움직임을 조금더 자연스럽게 바꿔도 좋을 것 같긴하다.
// 좀더 못하는 버전은 addForce위에 조건을 없애면 된다.
public class botController : MonoBehaviour
{
    GameObject ball;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("ball");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null) return;
        if (ball.transform.position.x < 3)
        {
            Vector2 tmp = rb.velocity;
            rb.velocity -= tmp * 0.3f;
        }
        if (ball.transform.position.y > transform.position.y)
        {
            if (rb.velocity.y < 0) rb.velocity -= rb.velocity * 0.3f;
            rb.AddForce(new Vector2(0, 40.0f));
        }
        else
        {
            if (rb.velocity.y > 0) rb.velocity -= rb.velocity * 0.3f;
            rb.AddForce(new Vector2(0, -40.0f));
        }

    }
}
