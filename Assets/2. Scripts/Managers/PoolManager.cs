using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i=0; i<pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject GetPoolObject(int index)
    {
        GameObject selectedObject = null;
        
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                selectedObject = item;
                selectedObject.SetActive(true);
                break;
            }
        }
        if(!selectedObject)
        {
            selectedObject = Instantiate(prefabs[index], transform);
            pools[index].Add(selectedObject);
        }

        return selectedObject;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}
