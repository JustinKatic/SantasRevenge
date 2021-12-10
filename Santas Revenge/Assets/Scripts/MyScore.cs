using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyScore : MonoBehaviour
{
    public int numberOfKilled = 0;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
}
