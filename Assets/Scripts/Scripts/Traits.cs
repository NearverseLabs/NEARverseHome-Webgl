using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class JsonData
{
    public string name;
    public string description;
    public string image;
    public attData[] attributes;
}

[System.Serializable]
public class attData
{
    public string trait_type;
    public string value;     
}

public class Traits : MonoBehaviour
{
    //public JsonData myMetaData = new JsonData();
    Dictionary<string, GameObject> m_dict = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            m_dict.Add(this.gameObject.transform.GetChild(1).GetChild(1).GetChild(i).name, 
            this.gameObject.transform.GetChild(1).GetChild(1).GetChild(i).gameObject);
        }
        for (int i = 0; i < 10; i++)
        {
            m_dict.Add(this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(i).name, 
            this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(i).gameObject);
        }
        for (int i = 0; i < 6; i++)
        {
            m_dict.Add(this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(10).GetChild(0).GetChild(0).GetChild(i).name, 
            this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(10).GetChild(0).GetChild(0).GetChild(i).gameObject);
        }
        for (int i = 0; i < 1; i++)
        {
            m_dict.Add(this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(i).name,
            this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(i).gameObject);
        }
        for (int i = 0; i < 37; i++)
        {
            m_dict.Add(this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(i).name,
            this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadCharacter(string jsonString)
    {
        //StreamReader reader = new StreamReader("Assets/Model/MetaData/751.json");
        //Debug.Log("stream reader: " + reader);
        //string json = reader.ReadToEnd();
        Debug.Log("Json String --------: " + jsonString);
        JsonData traits = JsonUtility.FromJson<JsonData>(jsonString);
        Debug.Log("traits: " + traits);

        for (int i = 0; i < traits.attributes.Length; i++)
        {
            if ((traits.attributes[i].trait_type == "Backpacks" || traits.attributes[i].trait_type == "Handheld Weapon" || traits.attributes[i].trait_type == "Head Mount" || traits.attributes[i].trait_type == "Holographic Text" || traits.attributes[i].trait_type == "Pendant") && traits.attributes[i].value != "None")
            {
                m_dict[traits.attributes[i].value].SetActive(true);
            }
        }
    }
}
