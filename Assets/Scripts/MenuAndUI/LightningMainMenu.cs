using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningMainMenu : MonoBehaviour
{
    Image imageComponent;
    public float flashSpeed = 5f;
    public float duration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //imageComponent.color = Color.Lerp(Color.black, Color.white, flashSpeed * Time.deltaTime);
        if (Random.Range(1f, 100f) > 98.5f)
        {
            //imageComponent.color = Color.white;
            imageComponent.color = Color.Lerp(new Color(0.5f, 0.5f, 0.5f, 1f), new Color(1f, 1f, 1f, 1f), Random.Range(0f, 1f));
        }
        else if (duration > 0.20f)
        {
            imageComponent.color = Color.black;
            duration = 0;
        }
        duration = duration + Time.deltaTime;
    }
}



