using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public void updateText(string newText)
    {
        GetComponent<Text>().text = newText;
    }
}
