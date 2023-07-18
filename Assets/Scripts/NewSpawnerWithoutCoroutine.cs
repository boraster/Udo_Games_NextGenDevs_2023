
using UnityEngine;

public class NewSpawnerWithoutCoroutine : MonoBehaviour
{
    public float spawnCooldown;
    public float objectLifetime;
    private GameObject spawned;
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    bool spawning;
    private float activationTimer = 0f;
   
    void Update()
    {
        activationTimer += Time.deltaTime;
        
        if (activationTimer>= spawnCooldown)
        {
            WaitAndSpawn();
            activationTimer = 0f;
        }
      
    }

    private void Start()
    {
        spawnPos = gameObject.transform.position;
        spawnRot = gameObject.transform.rotation;
    }

    void WaitAndSpawn() 
    {
       
            spawned = PoolingWithStack.SharedInstance.GetPooledObject();
            if (spawned != null)
            {
                 spawned.transform.position = spawnPos;
                            spawned.transform.rotation = spawnRot;
                            spawned.SetActive(true);
            }
           
        
    }

    

    
}
