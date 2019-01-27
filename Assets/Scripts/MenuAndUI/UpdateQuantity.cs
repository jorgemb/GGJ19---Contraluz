using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuantity : MonoBehaviour
{
    private Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<Text>();
    }

    public void updateNumber(int qty)
    {
        string newText;
        try
        {
            newText = qty.ToString();
            textComponent.text = newText;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.StackTrace);
        }
    }
}
