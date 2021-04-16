using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RunGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Game has been exited");
    }
}
