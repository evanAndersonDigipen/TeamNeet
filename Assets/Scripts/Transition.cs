using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    // Score amount to transition to the next level
    public int winScore = 0;
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.score >= winScore)
        {
            GameManager.ResetGame();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
