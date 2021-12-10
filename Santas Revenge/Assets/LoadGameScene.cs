using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    private void Start()
    {
        Invoke("NextScene", 17f);
    }
    void NextScene()
    {
        SceneManager.LoadScene("Game");
    }
}
