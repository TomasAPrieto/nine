using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Collider2D c2d;
    [SerializeField] private Sprite OpenDoor;
    private PlayerMovement thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            if(thePlayer.followingKey != null){
                //thePlayer.followingKey.followTarget = transform;
                Destroy(thePlayer.followingKey.gameObject);
                thePlayer.followingKey = null;
                sr.sprite = OpenDoor;
                c2d.isTrigger = true;
            }

        }
    }
}
