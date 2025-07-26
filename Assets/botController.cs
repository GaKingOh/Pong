using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ȶ��� �����̴�. �������� ���ݴ� �ڿ������� �ٲ㵵 ���� �� �����ϴ�.
// ���� ���ϴ� ������ addForce���� ������ ���ָ� �ȴ�.
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
