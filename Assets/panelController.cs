using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelController : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPaused = false;
    public GameObject panel;
    void Start()
    {
 
    }

    // Update is called once per frame
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        panel.SetActive(false); 
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }
}
