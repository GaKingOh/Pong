using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MyPongAgent : Agent
{
    Rigidbody2D rb;
    public Transform ball;
    GameObject ball2;
    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public override void OnEpisodeBegin()
    {
        // 에이전트 초기 위치 리셋
        transform.position = new Vector3(-7f, 0f, 0f);
        rb.velocity = Vector2.zero;

        // 공도 리셋하는 부분은 별도 공 스크립트에서 처리하는 게 좋음
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // 내 y 위치
        sensor.AddObservation(transform.position.y);

        // 공 위치 (x, y)
        sensor.AddObservation(ball.position.x);
        sensor.AddObservation(ball.position.y);

        // 공 속도 (x, y)
        sensor.AddObservation(ball.GetComponent<Rigidbody2D>().velocity.x);
        sensor.AddObservation(ball.GetComponent<Rigidbody2D>().velocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log("안녕");
        float moveY = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        rb.velocity = new Vector2(0, moveY * 5f);

        // 계속 움직이면 작은 보상 주기
        AddReward(0.001f);

        float distance = Mathf.Abs(ball.position.y - transform.position.y);
        float reward = 1f - Mathf.Clamp01(distance / 5f); // 거리가 멀면 보상 0, 가까우면 최대 1
        AddReward(reward * 0.1f);
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetKey(KeyCode.UpArrow) ? 1f :
                               Input.GetKey(KeyCode.DownArrow) ? -1f : 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            AddReward(1.0f); // 공을 튕기면 큰 보상
        }
    }
    void Update()
    {
        if (ball.position.x < -10f)  // 공이 왼쪽으로 나갔을 때
        {
            AddReward(-1.0f);  // 실패 보상
            EndEpisode();      // 에피소드 종료
        }
    }

}
