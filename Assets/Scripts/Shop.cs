using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    bool isActive;
    public GameObject panel;

	// Use this for initialization
	void Start () {
        isActive = false;
        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void shopEnable() {
        if (isActive)
            isActive = false;
        else
            isActive = true;

        panel.SetActive(isActive);
    }
}
