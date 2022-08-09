using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class click : MonoBehaviour
{
	[SerializeField]
	//Transform place;
	GameObject Player;
    Animator playerController;


    GameObject[] players;


	public GameObject panel;
	private GameObject[] all_panels; 
    
	GameObject player;
	public float x = 0;	
	public float y = 0;	
	public float z = 0;
	public float rot = 0;

	 void Awake()
    {	players = GameObject.FindGameObjectsWithTag("Player");
    	Player = players[0];
        // Get the rigidbody on this.
        playerController = Player.GetComponent<Animator>();
    }
	
	IEnumerator OnMouseUp()
	{
		all_panels = GameObject.FindGameObjectsWithTag("Panel");
		foreach (GameObject p in all_panels)
		{
			p.SetActive(false);

		}
		player = GameObject.FindGameObjectWithTag("Player");
		
		var curPosition = player.transform.position; 
		var targetPosition = new Vector3(x, y, z);
		
		var curRotation = player.transform.eulerAngles;
		if ((curRotation.y - rot) > 180 || (curRotation.y - rot) < -180 ){
			rot -= 360;
			if ((curRotation.y - rot) > 180 || (curRotation.y - rot) < -180 ){
				rot += 720;
			}
		}
		var targetRotation = new Vector3(0, rot, 0);
		
		for (float step = 0; step < 2; step += 0.01f){
			player.transform.position = Vector3.Lerp(curPosition, targetPosition, step);
			player.transform.eulerAngles = Vector3.Lerp(curRotation, targetRotation, step);
			yield return new WaitForSeconds(0.001f);			
		}	
		panel.SetActive(!panel.activeSelf);	
	
    }	
	
	void FixedUpdate()
	{

		if(panel.activeSelf)
		{	

			
			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))
			{	
				panel.SetActive(false);
				
			}
			
			if (Input.GetMouseButton(0) && !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition, null))
			{	
				panel.SetActive(false);
			}

		}
	}
}