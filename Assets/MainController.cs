using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    public void playOhKingGa()
    {
        SceneManager.LoadScene("OhkingScene");
    }
    public void playMlAgent()
    {
        SceneManager.LoadScene("MlScene");
    }
}
