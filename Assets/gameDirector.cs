using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameDirector : MonoBehaviour
{
    int player = 0;
    int bot = 0;
    GameObject text;
    void Start()
    {
        text = GameObject.Find("scoreBoard");
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
