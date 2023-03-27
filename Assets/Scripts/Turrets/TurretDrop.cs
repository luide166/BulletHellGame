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
    float maxDropPercentage;

    // Start is called before the first frame update
    void Start()
    {
        TurretHealth.TurretDead += DropColectables;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
