using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string nextSceneName;

    public void ChangeLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
