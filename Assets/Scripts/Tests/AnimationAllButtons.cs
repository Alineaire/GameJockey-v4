using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAllButtons : MonoBehaviour
{
    public ArduinoCommunication arduino;

    public int buttonNumber = 4;
    public float animationSpeed = 1f;
    public Color defautColor = Color.red;
    public Color animationColor = Color.cyan;

    public float position = 0f;
    float scriptTime;

    private void Update()
    {
        scriptTime += Time.deltaTime * animationSpeed;
        position = Mathf.PingPong(scriptTime, buttonNumber-1);

        for (int buttonIndex = 0; buttonIndex < buttonNumber; buttonIndex++)
        {
            Color c = defautColor;

            if (Mathf.RoundToInt(position) == buttonIndex)
                c = animationColor;

            arduino.SetButtonColor(buttonIndex, c);
        }

    }
}
