using UnityEngine;

public class closePanel : MonoBehaviour
{
	public GameObject panel;
    
	public void Close()
    {
        panel.SetActive(false);

    }


}
