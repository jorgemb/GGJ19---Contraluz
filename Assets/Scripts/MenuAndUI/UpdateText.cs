using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    private Image imageComponent;
    private Text hudText;
    private float ratio;

    public void Start()
    {      
        hudText = GetComponent<Text>();
        updateText("SCARED");
        ratio = 98.5f;
    }
    public void updateText(string newText)
    {
        hudText.text = newText;
    }

    public void Update()
    {
        if(GetComponent<Text>().text == "SCARED" && ratio > 50f)
        {
            ratio = 50f;
        }
        else if (ratio == 50f)
        {
            ratio = 98.5f;
        }

        if (Random.Range(1f, 100f) > ratio)
        {
            hudText.color = Color.black;
        }
        else
        {
            if (hudText.color != Color.green)
            {
                hudText.color = Color.green;
            }
        }
    }
}
