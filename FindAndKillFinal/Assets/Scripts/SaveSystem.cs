using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveSystem : MonoBehaviour
{
    private const string saveFileName = "Assets/Saves.game.xml";

    void Update(){
        if (Input.GetKeyDown(KeyCode.M))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
           //Load();
        }
    }

    public void Save() {
        XmlDocument xmlDocument = new XmlDocument();

    }




}
