using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click2 : MonoBehaviour
{
	public string Url;
    void OnMouseUp()
	{
		Application.OpenURL(Url);
    }	
	
}