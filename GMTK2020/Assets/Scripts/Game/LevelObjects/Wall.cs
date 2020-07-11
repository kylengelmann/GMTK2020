using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private void Start()
    {
        LevelGrid.Get().RegisterWall(this);
    }
}
