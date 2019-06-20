using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour {

    public GameObject gameController;
	public GameObject card1;
	public GameObject card2;
    public GameObject card3;
    [SerializeField]
    SpriteRenderer sprite1;
    [SerializeField]
    SpriteRenderer sprite2;
    [SerializeField]
    SpriteRenderer sprite3;

    public AudioSource aSource;



    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void randomMaterialsAndStatus()
    {
        card1.GetComponent<TMaterial>().type = Random.Range(0, 9);
        card1.GetComponent<TMaterial>().status = 1;
        card2.GetComponent<TMaterial>().type = Random.Range(0, 9);
        card2.GetComponent<TMaterial>().status = Random.Range(0, 2);
        card3.GetComponent<TMaterial>().type = Random.Range(0, 9);
        card3.GetComponent<TMaterial>().status = Random.Range(0, 2);
    }

    public void updateSprites()
    { 
        sprite1.sprite = gameController.GetComponent<GameController>().cardMaterials[card1.GetComponent<TMaterial>().type].GetComponent<SpriteRenderer>().sprite;
        sprite2.sprite = gameController.GetComponent<GameController>().cardMaterials[card2.GetComponent<TMaterial>().type].GetComponent<SpriteRenderer>().sprite;
        sprite3.sprite = gameController.GetComponent<GameController>().cardMaterials[card3.GetComponent<TMaterial>().type].GetComponent<SpriteRenderer>().sprite;

        if(card1.GetComponent<TMaterial>().status == 1)
            sprite1.color = new Color(0.980f, 0.502f, 0.447f, 1f);
        
        if (card2.GetComponent<TMaterial>().status == 1)
            sprite2.color = new Color(0.980f, 0.502f, 0.447f, 1f);

        if (card3.GetComponent<TMaterial>().status == 1)
            sprite3.color = new Color(0.980f, 0.502f, 0.447f, 1f);

    }

    public void generateClient()
    {
       randomMaterialsAndStatus();
       updateSprites();
    }

    public void isAll()
    {
        if (card1.GetComponent<TMaterial>().status == 0 && card2.GetComponent<TMaterial>().status == 0 && card3.GetComponent<TMaterial>().status == 0)
        {
            aSource.Play();
            gameController.GetComponent<GameController>().gold += 10;
			gameController.GetComponent<GameController> ().time += 10;
			gameController.GetComponent<GameController> ().clientsAttended += 1;
            gameController.GetComponent<GameController>().goldText.text = gameController.GetComponent<GameController>().gold.ToString();
            this.generateClient();
        }
    }
}
