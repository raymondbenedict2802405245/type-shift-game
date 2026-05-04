using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

public class JSONLoader : MonoBehaviour
{
    public static Dictionary<string, int> database;

    void Awake()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("words_dictionary");
        database = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonFile.text);
    }
}