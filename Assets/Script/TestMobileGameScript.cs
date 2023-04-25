using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TestMobileGameScript : MonoBehaviour
{
    public Text DataField;
    public Text FPSCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        DataField.text = SystemInfo.operatingSystem;
        Handheld.Vibrate();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches) // perhaps ask meeting person if event based possible
        {
            if (touch.phase == TouchPhase.Began)
            {
                DataField.text = SystemInfo.batteryLevel.ToString(CultureInfo.CurrentCulture);
            }
        }
        FPSCounter.text = (1f/Time.deltaTime).ToString(CultureInfo.CurrentCulture);
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
