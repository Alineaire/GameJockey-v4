using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public ArduinoCommunication arduino;

    public int buttonNumber = 4;
    public Color defautColor = Color.red;
    public Color inputColor = Color.cyan;

    private void Update()
    {

        for (int buttonIndex = 0; buttonIndex < buttonNumber; buttonIndex++)
        {
            Color c = defautColor;

            if (arduino.IsButtonPressed(buttonIndex))
                c = inputColor;

            arduino.SetButtonColor(buttonIndex, c);
        }

    }
}
