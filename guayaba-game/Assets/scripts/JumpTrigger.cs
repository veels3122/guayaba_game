using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //player
    playercontroller player;
    void Update()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playercontroller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Untagged")
        {
            player.OnGround = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Untagged")
        {
            player.OnGround = false;
        }
        
    }

}
