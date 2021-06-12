using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    public float rotationSpeed = 900f;
    [SerializeField]
    private Rigidbody playerBody;
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerBody.velocity = getVelocity();
        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);
    }

    Vector3 getVelocity(){

        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * playerSpeed, playerBody.velocity.y ,Input.GetAxisRaw("Vertical") * playerSpeed);
        Vector3 forwardVector = transform.forward * (Input.GetAxisRaw("Vertical") * playerSpeed);
        Vector3 strafeVector = transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
        inputVector = forwardVector + strafeVector;
        Vector3 gravityVector = new Vector3(0, playerBody.velocity.y, 0);
        
        return Vector3.ClampMagnitude(inputVector, playerSpeed) + gravityVector;
    }
}
