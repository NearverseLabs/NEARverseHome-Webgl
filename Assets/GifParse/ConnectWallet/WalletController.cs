using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

public class WalletController : MonoBehaviour
{
    public TextMeshProUGUI btnTxt;
    //public GameObject[] MyPhotos;
    [DllImport("__Internal")]
    private static extern void Connect();

    [DllImport("__Internal")]
    private static extern void Disconnect();

    [DllImport("__Internal")]
    private static extern void Getnfts();

    void Start()
    {

    }

    public void OnClickWalletConnect()
    {
        if (btnTxt.text == "Connect Wallet")
        {
            Connect();
        }
        else
        {
            Disconnect();
        }
    }

    public void displayPhotos()
    {
        Getnfts();
        //for(int i = 0; i < myphotos.length; i ++)
        //{

        //}
    }
    public void ChangeButtonText(string btnText)
    {
        btnTxt.text = btnText;
        Debug.Log("button text: --------------------" + btnTxt.text);
        if (btnText == "Disconnect Wallet")
        {
            Debug.Log("tried to connect wallet---------------");
            displayPhotos();
        }
    }
}