using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour {

	private int totalPoints;
	private int clientsAttended;
	private int totalGold;

	public Text points;
	public Text clients;
	public Text gold;
	public Text bestPlayer;

	// Use this for initialization
	void Start () {
		totalPoints = PlayerPrefs.GetInt ("totalPoints");
		clientsAttended = PlayerPrefs.GetInt ("clientsAttended");
		totalGold = PlayerPrefs.GetInt ("totalGold");

		points.text = "Total Points: " + totalPoints;
		clients.text = "Clients Attended: " + clientsAttended;
		gold.text = "Total Gold: " + totalGold;
		if (PlayerPrefs.HasKey ("record")) {
			if (PlayerPrefs.GetInt ("record") < totalPoints) {
				PlayerPrefs.SetInt ("record", totalPoints);
			}
		}  else 
			PlayerPrefs.SetInt ("record", totalPoints);
	}
	
	// Update is called once per frame
	void Update () {
		bestPlayer.text ="Best player: " + (PlayerPrefs.GetInt ("record")).ToString ();
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameObject.FindGameObjectWithTag ("Fade").GetComponent<Fade> ().LoadScene ("Menu");
		}
	}



}
