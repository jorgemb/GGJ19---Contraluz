using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSound : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        /**if (FindObjectOfType(typeof(StartGameSound)))
        {
            Destroy(transform.gameObject);
        }
        return;**/
    }
}
