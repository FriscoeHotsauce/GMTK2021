using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigfootSmash : MonoBehaviour
{

    public Animator bigFootAnimator;
    public Animator playerAnimator;
    public GameObject player;
    public ParticleSystem playerExplosion;
    public float explosionTimer = 3.2f;
    [SerializeField]
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    void Awake(){
        bigFootAnimator.Play("BasicMotions@Exclamation01");
        playerAnimator.Play("BasicMotions@Horror01_A");
    }

    void Update(){
        currentTime = currentTime + Time.deltaTime;
        if(currentTime > explosionTimer){
            Vector3 playerPosition = player.transform.position;
            Quaternion playerRotation = player.transform.rotation;
            Destroy(player);
            Instantiate(playerExplosion, playerPosition, playerExplosion.transform.rotation);
            Destroy(this);
        }
    }
}
