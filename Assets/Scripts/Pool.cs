using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;   //it is prafab of platform
    public int amount;  //total amount of a prafab that can be stored in the pool
    public bool expandable;
}
public class Pool : MonoBehaviour
{
    public static Pool singleton;   
    public List<PoolItem> items;    //list of all the prefabs which can be pooled
    public List<GameObject> pooledItems;    //list of all items which are instantiated in Hierarchy

    private void Awake()
    {
        singleton = this;
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    public GameObject GetRandom()
    {
        Utils.Shuffle(pooledItems);
        for(int i=0; i < pooledItems.Count; i++)
        {
            if(!pooledItems[i].activeInHierarchy)   //if it is not active in the Hierarchy, it means it is available to use
            {
                return pooledItems[i];
            }
        }
        
        foreach(PoolItem item in items)
        {
            if (item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
                return obj;
            }
        }

        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class Utils
{
    public static System.Random r = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
