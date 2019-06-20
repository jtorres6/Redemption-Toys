using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fade : MonoBehaviour {
	private Image gaviota;
	// Use this for initialization
	private Color transparentBlack;
	private bool loading;
	private string sceneName;
	void Start () {
		transparentBlack = new Color (0, 0, 0,0);
		gaviota = GetComponent<Image> ();
		FadeOut ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void LoadScene(string scene){
		loading = true;
		sceneName = scene;
		FadeIn ();
	}
	IEnumerator FadeInCoRoutine(){
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime) {
			gaviota.color = Color.Lerp (transparentBlack, Color.black, i);
			yield return 0;
		}
		gaviota.color = Color.black;
		if (loading) {
			SceneManager.LoadScene (sceneName);
		}
			
			
	}
	public void FadeIn(){
		gaviota.enabled = true;
		gaviota.color = transparentBlack;
		StartCoroutine (FadeInCoRoutine());
		
	}
	IEnumerator FadeOutCoRoutine(){
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime) {
			gaviota.color = Color.Lerp (Color.black, transparentBlack, i);
			yield return 0;
		}
		gaviota.color = transparentBlack;
		gaviota.enabled = false;
	}
	public void FadeOut(){
		gaviota.enabled = true;
		gaviota.color = Color.black;
		StartCoroutine (FadeOutCoRoutine());
	}


}
