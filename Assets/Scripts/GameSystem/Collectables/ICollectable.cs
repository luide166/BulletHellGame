using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollectable : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    public int value;
    [SerializeField]
    private Transform trans;
    private float timer = 0;
    private float stopMoveTime = 1;
    private Vector3 offset;

    private bool stopMove;
    [SerializeField]
    float timeToDestroy;
    


    private void Awake()
    {
        offset = new Vector3(Random.Range(-1.5F, 1.5F), Random.Range(-1.5F, 1.5F),trans.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        stopMove = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateCollectable()
    {
        if (stopMoveTime >= timer)
        {
            timer += Time.deltaTime;
            trans.position += offset * Time.deltaTime;
        }
        else
        {
            stopMove = false;
        }
    }

    public IEnumerator DestroyCollectable()
    {
        Destroy(gameObject, timeToDestroy);
        yield break;
    }

    public virtual IEnumerator AddCollectable(PlayerCollectables player)
    {
        yield break;
    }
}
