using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // states: currently spawning, waiting for player to kill the enemies, waiting for the next wave to be spawned
    public enum spawn_state { SPAWNING, WAITING, COUNTING};
    public manager manager;
    [System.Serializable]
    public class Wave
    {
        // identifier of wave
        public string id;
        // enemey class
        public Transform enemy_type;
        // # of enemies
        public int count;
        // # of enemies per second
        public float individual_spawn_interval;
        // Spawn location
        public Transform spawn_point;
    }
    public Wave[] waves;

    private int next_wave = 0; // init wave counter
    public float wave_interval = 5f;
    public float seconds_until_next_wave;

    public spawn_state state = spawn_state.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        seconds_until_next_wave = wave_interval;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (state == spawn_state.WAITING)
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").ToString());
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Debug.Log("wave completed");
                // if all enmeies have died, start counting down for the next wave
                    
                state = spawn_state.COUNTING; ;
                seconds_until_next_wave = wave_interval;
                if (next_wave >= waves.Length - 1)
                {
                    next_wave = 0;
                    Debug.Log("all waves completed");
                    manager.end_game();
                }
                next_wave += 1;
            }
            else
            {
                return;
            }

        }
        
        if (seconds_until_next_wave <= 0)
        {
            if (state != spawn_state.SPAWNING)
            {
                //start spawning
                StartCoroutine(spawn(waves[next_wave]));
            }
            seconds_until_next_wave = wave_interval;
        }
        else
        {
            seconds_until_next_wave -= Time.deltaTime;
        }
    }
    
    IEnumerator spawn (Wave wave)
    {
        state = spawn_state.SPAWNING;
        for (int i = 0; i < wave.count; i++)
        {
            Debug.Log("Spawning enemy: " + wave.enemy_type.name);
            Instantiate(wave.enemy_type, wave.spawn_point.position, wave.spawn_point.rotation);
            yield return new WaitForSeconds(wave.individual_spawn_interval);
        }

        state = spawn_state.WAITING;
        yield break;
    }
}
