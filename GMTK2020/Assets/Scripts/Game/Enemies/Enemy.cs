using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Coroutine StartTurn()
    {
        return StartCoroutine(TakeTurn());
    }

    protected virtual IEnumerator TakeTurn()
    {
        yield return new WaitForSeconds(1f);
    }
    
}
