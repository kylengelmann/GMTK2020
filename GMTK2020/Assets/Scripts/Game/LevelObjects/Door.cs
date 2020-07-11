using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void Start()
    {
        LevelGrid.Get().RegisterDoor(this);
    }
}
