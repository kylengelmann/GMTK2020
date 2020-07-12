using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIDisplay : MonoBehaviour
{
    public Image number;

    void Update()
    {
        int num = GetDisplayNum();

        number.sprite = GameManager.Get().Didgets[num % 10];
    }

    protected abstract int GetDisplayNum();

}
