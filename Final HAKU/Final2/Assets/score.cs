using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public manager manager;
    public Text ui_score;
    private void Update()
    {
        ui_score.text = "Score: " + manager.score.ToString();
    }
}
