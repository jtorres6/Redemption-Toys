using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChange : MonoBehaviour {

	Text t;
	// Use this for initialization
	void Start () {
		t =  GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		t.color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
		t.fontSize = Random.Range (30, 50);
	}
}
