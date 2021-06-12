using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction { forward, forwardRight, right, backwardRight, backward, backwardLeft, left, forwardLeft }

public class PlayerAnimator : MonoBehaviour
{

    public enum state { moving, idle }

    [SerializeField]
    private state previousState;
    [SerializeField]
    private direction previousDirection;
    private Vector3 previousPosition;
    private Animator animator;

    void Start(){
        previousDirection = direction.backward;
        previousState = state.idle;
        previousPosition = transform.position;
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate(){
        state currentState = determineIfIdle();
        bool stateChanged = currentState != previousState;
        direction deltaDirection = determineDirectionOfMotion();
        bool directionChange = previousDirection != deltaDirection;

        if(stateChanged || directionChange){
            if(currentState == state.idle){
                Debug.Log("State change " + stateChanged +" become idle");
                animator.Play("BasicMotions@Idle01");
            } else {
                Debug.Log("Direction change: " + deltaDirection);
                switch(deltaDirection){
                    case direction.forward:
                        animator.Play("BasicMotions@Walk01 - Forwards [RM]");
                        break;
                    case direction.forwardRight:
                        animator.Play("BasicMotions@Walk01 - ForwardsRight [RM]");
                        break;
                    case direction.right:
                        animator.Play("BasicMotions@Walk01 - Right [RM]");
                        break;
                    case direction.backwardRight:
                        animator.Play("BasicMotions@Walk01 - BackwardsRight [RM]");
                        break;
                    case direction.backward:
                        animator.Play("BasicMotions@Walk01 - Backwards [RM]");
                        break;
                    case direction.backwardLeft:
                        animator.Play("BasicMotions@Walk01 - BackwardsLeft [RM]");
                        break;
                    case direction.left:
                        animator.Play("BasicMotions@Walk01 - Left [RM]");
                        break;
                    case direction.forwardLeft:
                        animator.Play("BasicMotions@Walk01 - ForwardsLeft [RM]");
                        break;
                }
                 previousDirection = deltaDirection;
            }
        } 

        previousState = currentState;
        previousPosition = transform.position;
    }
    
    private direction determineDirectionOfMotion(){
        Vector3 postitionDelta = transform.position - previousPosition;
        postitionDelta = transform.InverseTransformDirection(postitionDelta);
        if(Mathf.Abs(postitionDelta.x) > Mathf.Abs(postitionDelta.z)){
            //we primarily strafing
            if(postitionDelta.x > 0){
                if(Mathf.Abs(postitionDelta.z) > 0.01f) {
                    if(postitionDelta.z > 0){
                        return direction.forwardRight;
                    } else {
                        return direction.backwardRight;
                    }
                } else {
                    return direction.right;
                }

            } else {
                if(Mathf.Abs(postitionDelta.z) > 0.1f){
                    if(postitionDelta.z > 0){
                        return direction.forwardLeft;
                    } else {
                        return direction.backwardLeft;
                    }
                } else {
                    return direction.left;
                }
            }

        } else {
            //we are primarily moving forward or backwards
            if(postitionDelta.z > 0){
                if(Mathf.Abs(postitionDelta.x) > 0.1f){
                    if(postitionDelta.x > 0){
                        return direction.forwardRight;
                    } else {
                        return direction.forwardLeft;
                    }
                } else {
                    return direction.forward;
                }
            } else {
                if(Mathf.Abs(postitionDelta.x) > 0.1f){
                    if(postitionDelta.x > 0){
                        return direction.backwardRight;
                    } else {
                        return direction.backwardLeft;
                    }
                } else {
                    return direction.backward;
                }
            }
        }
    }

    private state determineIfIdle(){
        Vector3 postitionDelta = transform.position - previousPosition;
        postitionDelta = transform.InverseTransformDirection(postitionDelta);

        // Debug.Log("PositionDelta x: "+ postitionDelta.x + " | positionDelta y: "+postitionDelta.y);
        if(Mathf.Abs(postitionDelta.x) > 0.001f  || Mathf.Abs(postitionDelta.z) > 0.001f){
            Debug.Log("PositionDelta x: "+ postitionDelta.x + " | positionDelta z: "+postitionDelta.z);
            return state.moving;
        } else {
            return state.idle;
        }
    }

    public direction getCurrentDirection(){
        return previousDirection;
    }
}
