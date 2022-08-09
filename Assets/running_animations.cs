using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class running_animations : MonoBehaviour
{
    public GameObject Player;
    Animator playerController;

   

    void Awake()
    {
        // Get the rigidbody on this.
        playerController = Player.GetComponent<Animator>();
        playerController.GetComponent<Animator>().Play("Jump");
    }


    void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.LeftShift)){
			playerController.GetComponent<Animator>().Play("Run");
		
		}else if(Input.GetKey("w")){
			playerController.GetComponent<Animator>().Play("Walking");
		
		}else if(Input.GetKey("a")){
			playerController.GetComponent<Animator>().Play("Walking");
		
		}else if(Input.GetKey("d")){
			playerController.GetComponent<Animator>().Play("Walking");

		}else if(Input.GetKey("s")){
			playerController.GetComponent<Animator>().Play("Walking");

		}else if(Input.GetKey(KeyCode.Space)){
			playerController.GetComponent<Animator>().Play("Jump");
		

		}else{
			playerController.GetComponent<Animator>().Play("Default (Breathing)");
		}


    }
}