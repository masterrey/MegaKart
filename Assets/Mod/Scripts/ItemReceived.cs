using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceived : MonoBehaviour
{
    public GameObject[] items;
    public int count;
    public bool itenPresent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetItem()
    {
        if (!itenPresent)
        {
            return null;
        }
        itenPresent = false;

        return items[count];
    }

    public void Receive()
    {
        itenPresent=true;
        count = Random.Range(0, items.Length);
    }
}
