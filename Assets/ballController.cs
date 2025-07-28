using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject gameDirector;
    int[] direction = { -1, 1 };
    AudioSource ad;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.AddForce(new Vector2(100f * direction[Random.Range(0, 2)], Random.Range(80, 100)) * 2);
        gameDirector = GameObject.Find("gameDirector");
        ad = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        ad.Play();
        if (rb.velocity.magnitude > 15) return; // 공의 최대 속도
        rb.velocity *= 1.05f;
    }
    void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;

        rb.AddForce(new Vector2(100f * direction[Random.Range(0, 2)], Random.Range(80, 100)) * 2);
    }
    void Update()
    {
        while (rb.velocity.magnitude < 3 && rb.velocity.magnitude != 0)
        {
            rb.velocity += rb.velocity.normalized * 0.5f;
        }
        if (transform.position.x < -10 || transform.position.x > 10) // -10~10 까지 공이 이동할 수 있는 범위
        {
            if (transform.position.x < -10)
            {
                gameDirector.GetComponent<gameDirector>().PlusBot();
            }
            else
            {
                gameDirector.GetComponent<gameDirector>().PlusPlayer();
            }
            ResetBall();
        }
    }
}
