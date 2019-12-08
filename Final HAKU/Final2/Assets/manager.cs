using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public int score = 0;
    bool ended = false;
    public movement player;
    public void end_game()
    {
        if (!ended)
        {
            ended = true;
            Debug.Log("game over");
            if (player.health < 0)
            {
                SceneManager.LoadScene("Failed");
            }
            else
            {
                SceneManager.LoadScene("Congratulations");
            }
            
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
