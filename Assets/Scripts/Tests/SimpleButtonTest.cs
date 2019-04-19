using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButtonTest : MonoBehaviour
{
    public ArduinoCommunication arduino;

    public int buttonNumber = 4;
    public Color buttonColor = Color.red;

    private void Update()
    {
        for(int buttonIndex=0; buttonIndex<buttonNumber; buttonIndex++)
        {
            arduino.SetButtonColor(buttonIndex, buttonColor);
        }
        
    }
}
