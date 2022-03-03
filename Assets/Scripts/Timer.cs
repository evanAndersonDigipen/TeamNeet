using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    // Time since level started
    private float time;

    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        ChangeText();
    }

    private void ChangeText()
    {
        text.text = "Current Time: 0";

    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = $"Current Time: {Mathf.Round(time * 100) / 100f}";
    }
}
