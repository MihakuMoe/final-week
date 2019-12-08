using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_text : MonoBehaviour
{
    // Start is called before the first frame update
    public movement player;
    public Text health_ui;
    private void Update()
    {
        health_ui.text = "Health: " + player.health.ToString();
    }
}
