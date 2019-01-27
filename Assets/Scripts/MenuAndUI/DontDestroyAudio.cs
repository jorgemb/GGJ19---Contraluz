using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Update()
    {
        /**if (FindObjectOfType(typeof(StartGameSound)))
        {
            Destroy(transform.gameObject);
        }
        return;**/
    }
}
