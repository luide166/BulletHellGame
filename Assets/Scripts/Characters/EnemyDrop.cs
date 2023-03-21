using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    private GameObject[] itensToDrop;

    void Start()
    {
        EnemyHealth.Dead += Dropcollectables;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dropcollectables()
    {

    }
}
