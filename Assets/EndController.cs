using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{

    public float fadeOutTime = 5f;
    public float fadeOutDelay = 5f;
    public Image blackOutImage;
    public Text bangText;
    [SerializeField]
    private float fadeTime;
    [SerializeField]
    private float delayTime;
    [SerializeField]
    private bool delay;
    // Start is called before the first frame update
    void Start()
    {
        fadeTime = 0f;
        delayTime = 0f;
        delay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(delay){
            delayTime = delayTime + Time.deltaTime;
            if(delayTime > fadeOutDelay){
                delay = false;
                Destroy(bangText);
            }
        }
        if(fadeTime < fadeOutTime && !delay){
             fadeTime = fadeTime + Time.deltaTime;
            Color temp = blackOutImage.color;
            temp.a = 1 - (fadeTime / fadeOutTime);
            blackOutImage.color = temp;
        } else if(fadeTime >= fadeOutTime) {
            Destroy(blackOutImage);
            Destroy(this);
        }

    }
}
