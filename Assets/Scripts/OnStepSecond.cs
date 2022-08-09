using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStepSecond : MonoBehaviour
{
		  
	public Animator enterController;
	
	
    void OnTriggerEnter(Collider other)
    {
		if(other.CompareTag("Player")){
			enterController.SetBool("open_door", true);
		}   
	}

    void OnTriggerStay(Collider other)
    {
		if(other.CompareTag("Player")){
			enterController.SetBool("open_door", true);
		}     
	}
	
	void OnTriggerExit(Collider other)
    {

		if(other.CompareTag("Player")){
			enterController.SetBool("open_door", false);
		} 
    }
}
