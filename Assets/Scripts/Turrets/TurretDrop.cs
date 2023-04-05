using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDrop : MonoBehaviour
{
    [Header("Turret Info")]
    public string name;
    public int cost;
    [SerializeField]
    private GameObject itemToDrop;

    [Header("Drop Info")]
    [SerializeField]
    float minDropPercentage;
    [SerializeField]
    float maxDropPercentage;

    public void DropColectables()
    {
        float dropPercentage = Random.Range(minDropPercentage, maxDropPercentage);
        int value = (int)(cost * dropPercentage / 100);
        for (int i = 0; i < value; i++)
        {
            Instantiate(itemToDrop, transform.position, transform.rotation);
        }
    }
}
