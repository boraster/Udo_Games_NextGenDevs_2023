using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PoolingScript : MonoBehaviour
{
    public static PoolingScript SharedInstance;
   public List<GameObject> preinstantiatedObjects;
    public List<GameObject>  objectsToPool;
    public int amountToPool;
    private NewSpawnerWithoutCoroutine newSpawner;

    void Awake()
    {
        SharedInstance = this;
        newSpawner = FindObjectOfType<NewSpawnerWithoutCoroutine>();
    }
    void Start()
    {
        preinstantiatedObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Count)]);
            tmp.SetActive(false);
             // tmp.GetComponent<DeactivateObject>().objectLifeTime = newSpawner.objectLifetime;
            
            preinstantiatedObjects.Add(tmp);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!preinstantiatedObjects[i].activeInHierarchy)
            {
                return preinstantiatedObjects[i];
            }
        }
        return null;
    }
    
    
}
