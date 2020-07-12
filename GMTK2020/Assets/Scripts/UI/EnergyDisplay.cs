using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : UIDisplay
{
    protected override int GetDisplayNum()
    {
        return LevelManager.Get().hand.Energy;
    }
}
