using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideableElement : MonoBehaviour
{
    public void Hide()
    {
        gameObject.active = false;
    }

    public void Show()
    {
        gameObject.active = true;
    }

    public void CheckToggle(Toggle toggle)
    {
        if (toggle.isOn)
            Hide();
        else
            Show();
    }
}
