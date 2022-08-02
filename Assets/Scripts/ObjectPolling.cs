using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPolling : MonoBehaviour
{
    //https://www.youtube.com/watch?v=nf3gXt5m3Fc
    public static ObjectPolling current;
    public GameObject poolerObject;
    public int pooledAmount;
    public bool willGrwow;
    private List<GameObject> poolerObjects = new List<GameObject>();
    void Start()
    {
        current = this; 
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(poolerObject);
            obj.SetActive(false);
       //     Debug.Log("deberia funcionar");
            poolerObjects.Add(obj);
        
        }
    }
public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolerObjects.Count; i++)
        {
            Debug.Log("entro al loop");
            if (!poolerObjects[i].activeInHierarchy)
            {
                return poolerObjects[i];
            }
        }
        if (willGrwow)
        {
            GameObject obj = Instantiate(poolerObject);
            poolerObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
