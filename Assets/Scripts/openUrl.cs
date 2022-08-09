using UnityEngine;

public class openUrl : MonoBehaviour
{
	public string Url;
    
	public void Open()
    {
        Application.OpenURL(Url);
    }


}
