using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text = "X" + LevelManager.Get().hand.Energy.ToString();
    }
}
