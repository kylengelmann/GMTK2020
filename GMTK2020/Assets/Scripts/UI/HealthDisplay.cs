using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text = "X" + LevelManager.Get().playerObject.GetHealth().ToString();
    }
}
