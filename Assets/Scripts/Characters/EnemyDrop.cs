using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField]
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
        int value = this.GetComponent<EnemyHealth>().DropAmount() ;
        for (int i = 0; i < value; i++)
        {
            Instantiate(itensToDrop[1], transform.position, transform.rotation);
        }

    }
}