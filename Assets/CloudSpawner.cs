using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    
    public List<GameObject> cloudPrefabs;
    public float cloudSpawnInterval = 10f;
    public int maxClouds = 30;
    public int xMaxDrift = 250;
    public int yMaxDrift = 25;
    public float cloudSpawnRandomnesInterval = 2.5f;
    [SerializeField]
    private List<GameObject> clouds;
    private float nextSpawnTime;

    void Start(){
        nextSpawnTime = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time > nextSpawnTime && clouds.Count < maxClouds){
            spawnCloud();
            nextSpawnTime = nextSpawnTime + cloudSpawnInterval + Random.Range(-cloudSpawnRandomnesInterval, cloudSpawnRandomnesInterval);
        }
    }

    void spawnCloud(){
        GameObject cloudPrefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Count -1)];
        Vector3 drift = new Vector3(transform.position.x + Random.Range(-xMaxDrift, xMaxDrift), transform.position.y + Random.Range(-yMaxDrift, yMaxDrift), 0f);
        
        GameObject createdCloud = Instantiate(cloudPrefab, drift, transform.rotation);
        createdCloud.transform.SetParent(transform);
        createdCloud.GetComponent<CloudDrifter>().setCloudSpawner(this);
        clouds.Add(createdCloud);
    }

    public void removeCloud(GameObject cloud){
        clouds.Remove(cloud);
    }
}
