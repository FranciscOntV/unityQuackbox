using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    private Button self;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Button>();
    }

    public void Select() {
        self.image.color = Color.gray;
    }

    public void Deselect() {
        self.image.color = Color.white;
    }
}
