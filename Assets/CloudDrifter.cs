using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrifter : MonoBehaviour
{

    public float cloudSpeed = 10.0f;
    public Vector3 previousPosition;
    public float distanceTraveled;
    public CloudSpawner cloudSpawner;
    public float maxDistance = 700;
    // Update is called once per frame

    void Start(){
        cloudSpeed = cloudSpeed + Random.Range(-2f, 2f);
        previousPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * cloudSpeed);
        distanceTraveled = distanceTraveled + Vector3.Distance(previousPosition, transform.position);
        previousPosition = transform.position;
        if(distanceTraveled > maxDistance){
            cloudSpawner.removeCloud(gameObject);
            Destroy(gameObject);
        }
    }

    public void setCloudSpawner(CloudSpawner cloudSpawner){
        this.cloudSpawner = cloudSpawner;
    }
}
