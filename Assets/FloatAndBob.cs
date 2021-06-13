using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum dir { up, down }

public class FloatAndBob : MonoBehaviour
{
    public float maxBob = 1.0f;
    public float currentBob;
    public dir currentDirection;
    public float bobSpeed = 2f;
    public float rotationSpeed;
    

    void Start()
    {
        currentBob = 0f;
        currentDirection = dir.up;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDirection == dir.up){
            transform.Translate(transform.up * Time.deltaTime * bobSpeed);
            transform.Rotate(new Vector3(0f, rotationSpeed, 0f), Space.Self);
            currentBob = currentBob + Time.deltaTime;
            if(currentBob > maxBob){
                currentDirection = dir.down;
            }
        } else {
            transform.Translate(-transform.up * Time.deltaTime * bobSpeed);
            transform.Rotate(new Vector3(0f, rotationSpeed, 0f), Space.Self);
            currentBob = currentBob - Time.deltaTime;
            if(currentBob < -maxBob){
                currentDirection = dir.up;
            }
        }
        
    }
}
