using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private Button thisButton;
    
    void Start()
    {
        thisButton.GetComponent<Button>();
    }

    void turnButtonInactive(bool isOn) {
        thisButton.interactable = isOn;
    }


}
