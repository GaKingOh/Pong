using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PongAgent : Agent
{
    Rigidbody2D rb;
    public Transform ball;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public override void OnEpisodeBegin()
    {
        // �е� ��ġ �ʱ�ȭ
        transform.position = new Vector3(-7f, 0f, 0f); // player ���� ��ġ
        rb.velocity = Vector2.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.y); // �� ��ġ
        sensor.AddObservation(ball.position.x);      // �� ��ġ
        sensor.AddObservation(ball.position.y);
        sensor.AddObservation(ball.GetComponent<Rigidbody2D>().velocity); // �� �ӵ�
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveY = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        rb.AddForce(new Vector2(0, moveY * 10f));
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetKey(KeyCode.UpArrow) ? 1f :
                               Input.GetKey(KeyCode.DownArrow) ? -1f : 0f;
    }
}
