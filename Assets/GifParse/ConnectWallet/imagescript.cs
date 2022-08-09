using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;

[System.Serializable]
public class MetaData
{
    public string collection;
    public string marketplaceUrl;
    public string media;
}

[System.Serializable]
public class MetaDataList
{
    public MetaData[] items;
}

[System.Serializable]
public class imagescript : MonoBehaviour
{
    public TextAsset testText;
    public RawImage[] resultImage;
    public MetaDataList myMetaData = new MetaDataList();
    public openUrl[] openUrls;
    public MeshRenderer[] imageToDisplay;
    public Texture2D texture;
    public TextMeshProUGUI[] collectionName;
    public List<UniGif.GifTexture> m_gifTextureList;

    [SerializeField]
    private UniGifImage[] m_uniGifImage;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start coroutine");
        //StartCoroutine(ViewGifCoroutine("https://nobrainersnft.com/static/media/eth_spin.7fd5faac.gif"));
        //StartCoroutine(loadSpriteImageFromUrl(myMetaData.items[i].media, i));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SetGifImages(List<UniGif.GifTexture> _gifImgs)
    //{
    //    m_gifTextureList = _gifImgs;
    //    m_gifTextureIndex = 0;
    //    m_delayTime = Time.time;
    //}
    public void DisplaySprite(string jsonData)
    {
        Debug.Log("jsonString" + jsonData);
        string testString = testText.text;
        //Debug.Log("jsonString" + jsonData);

        //json convert to array
        //var metadata = CreateFromJSON(jsonData);
        //var metadata = JsonHelper.FromJson(metadata);
        //Debug.Log("jsonarray---------" + metadata);

        myMetaData = JsonUtility.FromJson<MetaDataList>(testString);
        Debug.Log("Array-------------" + myMetaData.GetType());

        //StartCoroutine(ViewGifCoroutine());
        for (int i = 0; i < myMetaData.items.Length; i++)
        {
            Debug.Log("sub data: " + myMetaData.items[i].media);
            StartCoroutine(loadSpriteImageFromUrl(myMetaData.items[i].media, i));
            if (openUrls[i])
            {
                openUrls[i].Url = myMetaData.items[i].marketplaceUrl;
            }
            if (collectionName[i])
            {
                collectionName[i].text = myMetaData.items[i].collection;
            }
        }
    }

    IEnumerator loadSpriteImageFromUrl(string URL, int i)
    {
        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            Debug.Log("Download image on progress" + www.progress);
            yield return null;
        }

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download failed");
        }
        else
        {
            Debug.Log("Download succes");
            if (www.bytes[0] != 'G' || www.bytes[1] != 'I' || www.bytes[2] != 'F')
            {
                texture = new Texture2D(1, 1);
                www.LoadImageIntoTexture(texture);
                if (i > 5)
                {
                    texture = rotateTexture(texture, false);
                }
                else
                {
                    texture = rotateTexture(texture, true);
                }
                if (imageToDisplay[i] && texture)
                {
                    imageToDisplay[i].material.mainTexture = texture;
                    imageToDisplay[i].material.SetTexture("_EmissionMap", texture);
                }
                if (resultImage[i])
                {
                    resultImage[i].texture = texture;
                }
            }
            else
            {
                StartCoroutine(m_uniGifImage[i].SetGifFromUrlCoroutine(URL));
            }

        }
    }
    Texture2D rotateTexture(Texture2D originalTexture, bool clockwise)
    {
        Color32[] original = originalTexture.GetPixels32();
        Color32[] rotated = new Color32[original.Length];
        int w = originalTexture.width;
        int h = originalTexture.height;

        int iRotated, iOriginal;

        for (int j = 0; j < h; ++j)
        {
            for (int i = 0; i < w; ++i)
            {
                iRotated = (i + 1) * h - j - 1;
                iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                rotated[iRotated] = original[iOriginal];
            }
        }

        Texture2D rotatedTexture = new Texture2D(h, w);
        rotatedTexture.SetPixels32(rotated);
        rotatedTexture.Apply();
        return rotatedTexture;
    }

    private IEnumerator ViewGifCoroutine(string imgUrl)
    {
        yield return StartCoroutine(m_uniGifImage[0].SetGifFromUrlCoroutine(imgUrl));
    }

}