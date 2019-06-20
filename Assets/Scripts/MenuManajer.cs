using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManajer : MonoBehaviour {

	public void Facil(){
		PlayerPrefs.SetInt ("tiempo", 120);
		GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>().LoadScene("CToys");
	}


	public void Normal(){ 
		PlayerPrefs.SetInt ("tiempo", 45);
		GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>().LoadScene("CToys");

	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
