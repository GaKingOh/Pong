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
        // ������Ʈ �ʱ� ��ġ ����
        transform.position = new Vector3(-7f, 0f, 0f);
        rb.velocity = Vector2.zero;

        // ���� �����ϴ� �κ��� ���� �� ��ũ��Ʈ���� ó���ϴ� �� ����
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // �� y ��ġ
        sensor.AddObservation(transform.position.y);

        // �� ��ġ (x, y)
        sensor.AddObservation(ball.position.x);
        sensor.AddObservation(ball.position.y);

        // �� �ӵ� (x, y)
        sensor.AddObservation(ball.GetComponent<Rigidbody2D>().velocity.x);
        sensor.AddObservation(ball.GetComponent<Rigidbody2D>().velocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log("�ȳ�");
        float moveY = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        rb.velocity = new Vector2(0, moveY * 5f);

        // ��� �����̸� ���� ���� �ֱ�
        AddReward(0.001f);

        float distance = Mathf.Abs(ball.position.y - transform.position.y);
        float reward = 1f - Mathf.Clamp01(distance / 5f); // �Ÿ��� �ָ� ���� 0, ������ �ִ� 1
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
            AddReward(1.0f); // ���� ƨ��� ū ����
        }
    }
    void Update()
    {
        if (ball.position.x < -10f)  // ���� �������� ������ ��
        {
            AddReward(-1.0f);  // ���� ����
            EndEpisode();      // ���Ǽҵ� ����
        }
    }

}
