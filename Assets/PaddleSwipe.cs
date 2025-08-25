using UnityEngine;
using System;
public class PaddleSwipe : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // y축 이동만 반영
                float dy = touch.deltaPosition.y * moveSpeed * 100;
                float value = Math.Min(Math.Abs(dy), 200.0f);
                if (dy < 0) value = -1 * value;

                rb.AddForce(new Vector2(0, 1.0f) * value);
       
            }
        }
        else rb.velocity = rb.velocity * 0.95f;
    }
}