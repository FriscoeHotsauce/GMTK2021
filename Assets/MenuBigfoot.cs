using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBigfoot : MonoBehaviour
{

    public Animator bfAnimator;
    private Transform theSun;
    private BFState currentState;
    public float sunTransparency = 0.1f;

    public List<Material> bfMaterials;


    // Start is called before the first frame update
    void Start()
    {
        currentState = BFState.sun;
        theSun = GameObject.FindGameObjectWithTag("TheSun").transform;

    }

    // Update is called once per frame
    void Awake()
    {
        bfAnimator.Play("BasicMotions@Idle01");
    }

    void Update(){
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
        modifyTransparency(1f);
    }

    private void setSun(){
        Debug.Log("Sun, put on some screen");
        modifyTransparency(sunTransparency);
    }
     private void modifyTransparency(float transparency){
        foreach(Material material in bfMaterials){
            Color temp = material.color;
            temp.a = transparency;
            material.color = temp;
        }
    }
}
