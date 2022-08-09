using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	
	public UnityEngine.Video.VideoPlayer videoPlayer;
	public string name;
	 
    void Start()
    {
		videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath, name); 
		videoPlayer.Play();
		videoPlayer.playOnAwake = true;    
		videoPlayer.isLooping = true;


	}
}