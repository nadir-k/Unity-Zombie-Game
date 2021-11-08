using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunData : MonoBehaviour
{

    public Gun gun;
    public Text gunText;
    public Text ammoText;

    // Update is called once per frame
    void Update()
    {
        gunText.text = gun.GetName();
        ammoText.text = gun.GetCurrentAmmo().ToString() + " / " + gun.GetMaxAmmo().ToString();
    }
}
