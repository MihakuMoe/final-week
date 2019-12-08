using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2_logic : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
