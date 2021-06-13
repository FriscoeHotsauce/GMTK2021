using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEnder : MonoBehaviour
{
    CapsuleCollider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CapsuleCollider>();
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
}