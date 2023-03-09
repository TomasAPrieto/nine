using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private bool isFollowing;
    public float followingSpeed;
    public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing){
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followingSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
            if(!isFollowing){
                PlayerMovement thePlayer = FindObjectOfType<PlayerMovement>();
                followTarget = thePlayer.keyFollowPoint;
                isFollowing = true;
                thePlayer.followingKey = this;
            }

        }
    }
}
