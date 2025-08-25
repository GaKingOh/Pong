using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameDirector : MonoBehaviour
{
    int player = 0;
    int bot = 0;
    GameObject text;
    Transform Player;
    Transform Bot;
    void Start()
    {
        text = GameObject.Find("scoreBoard");
        Player = GameObject.Find("player").GetComponent<Transform>();
        Bot = GameObject.Find("bot").GetComponent<Transform>();
    }

    public void SetPosition()
    {
        Player.transform.position = new Vector2(-9f, 0);
        Bot.transform.position = new Vector2(9f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TextMeshProUGUI>().text = player + "   " + bot;
    }
    public void PlusPlayer()
    {
        player++;
    }
    public void PlusBot()
    {
        bot++;
    }
}
