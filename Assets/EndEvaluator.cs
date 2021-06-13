using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndEvaluator : MonoBehaviour
{
    // Start is called before the first frame update

    public float distanceBetweenLovers;
    public Transform player;
    public Transform bigFoot;
    public float endDistance = 1.2f;
    public BigFootController bfController;
    void Start()
    {
        distanceBetweenLovers = 1000f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceBetweenLovers = Vector3.Distance(player.position, bigFoot.position);
        if(distanceBetweenLovers < endDistance && bfController.GetBFState() == BFState.shade){
            SceneManager.LoadScene(4, LoadSceneMode.Single);
        }
    }
}
