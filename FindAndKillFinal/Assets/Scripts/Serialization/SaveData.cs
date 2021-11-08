using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField]
    private Rifle rifleData = new Rifle();

    public void saveIntoJson() {
        string rifle = JsonUtility.ToJson(rifleData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/rifleData.json", rifle);
    }
}

[System.Serializable]
public class Rifle {
    public int rifleAmmo;
}

[System.Serializable]
public class Pistol {
    public int pistolAmmo;
}

[System.Serializable]
public class Score {
    public int score;
    public int currentKilled;
    public int remaining;
    public int wave;
}
