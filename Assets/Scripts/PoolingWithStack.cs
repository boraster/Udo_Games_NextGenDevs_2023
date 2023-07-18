using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingWithStack : MonoBehaviour
{
    public static PoolingWithStack SharedInstance;
    public Stack<GameObject> preinstantiatedObjects;
    public List<GameObject> objectsToPool;
    public int amountToPool;
    private NewSpawnerWithoutCoroutine newSpawner;
    private GameObject instantiatedGameobject;

    private void Awake()
    {
        SharedInstance = this;
        newSpawner = FindObjectOfType<NewSpawnerWithoutCoroutine>();
    }

    private void Start()
    {
        preinstantiatedObjects = new Stack<GameObject>();

        for (var i = 0; i < amountToPool; i++)
        {
            instantiatedGameobject = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Count)]);
            instantiatedGameobject.SetActive(false);
            preinstantiatedObjects.Push(instantiatedGameobject);
        }
    }

    public GameObject GetPooledObject()
    {
        preinstantiatedObjects.TryPop(out var pulledItem);
        if (!pulledItem.activeInHierarchy)
        {
            StartCoroutine(ReturnItemToPool(
                preinstantiatedObjects, pulledItem, newSpawner.objectLifetime));

            return pulledItem;
        }

        return null;
    }

    private IEnumerator ReturnItemToPool(Stack<GameObject> collection, GameObject returnedItem, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        returnedItem.SetActive(false);
        collection.Push(returnedItem);
    }
}