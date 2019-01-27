using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public float contador;
    public float onScreenTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador > onScreenTime)
        {
            SceneManager.LoadScene(1);
        }
        contador = contador + Time.deltaTime;

    }
}
