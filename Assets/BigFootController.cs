using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigFootController : MonoBehaviour
{
    public float navUpdateInterval = 0.5f;
    public float shadeSpeed = 3.5f;
    public float sunSpeed = 2.0f;
    public float sunTransparency = 0.7f;

    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform player;
    private Transform theSun;
    private Animator animator;
    private float nextNavUpdateTime;
    private BFState currentState;
    public List<Material> bfMaterials;
    private bool stateChange;

    public enum BFState{shade,sun}

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        theSun = GameObject.FindGameObjectWithTag("TheSun").transform;
        agent.SetDestination(player.position);
        nextNavUpdateTime = navUpdateInterval;
    }

    void FixedUpdate(){
        if(Time.time > nextNavUpdateTime){
            agent.SetDestination(player.position);
            nextNavUpdateTime = Time.time + navUpdateInterval;
        }
        updateBFState();
    }

    

    private void updateBFState(){
        Ray ray = new Ray();
        RaycastHit hit;
        BFState previousState = currentState;
        ray.origin = transform.position;
        ray.direction = (theSun.position - transform.position).normalized;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            currentState = BFState.shade;
        } else {
            Debug.DrawRay(ray.origin, ray.direction, Color.white);
            currentState = BFState.sun;
        }

        if(previousState != currentState){
            if(currentState == BFState.shade){
                setShade();
            } else {
                setSun();
            }
        }
    }
    
    private void setShade(){
        Debug.Log("Shady, of the slim variety");
        agent.speed = shadeSpeed;
        animator.Play("Sprint");
        modifyTransparency(1f);
        navUpdateInterval = .05f;
    }

    private void setSun(){
        Debug.Log("Sun, put on some screen");
        agent.speed = sunSpeed;
        animator.Play("Walk");
        modifyTransparency(sunTransparency);
        navUpdateInterval = 1.5f;
    }

    private void modifyTransparency(float transparency){
        foreach(Material material in bfMaterials){
            Color temp = material.color;
            temp.a = transparency;
            material.color = temp;
        }
    }
}
