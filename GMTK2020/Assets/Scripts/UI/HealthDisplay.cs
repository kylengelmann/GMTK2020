using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : UIDisplay
{
    protected override int GetDisplayNum()
    {
        return LevelManager.Get().playerObject.GetHealth();
    }
}
