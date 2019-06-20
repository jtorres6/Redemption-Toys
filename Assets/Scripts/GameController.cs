using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Text
    public Text goldText;

    public GameObject repair_collider1;
    public GameObject repair_collider2;

    //Cartas en reparación
    public GameObject repair1;
    public GameObject repair2;

	// Clients:
	public GameObject client1;
	public GameObject client2;
	public GameObject client3;
	public int clientsAttended;


    //Clients material request:
    public GameObject client1_1;
    public GameObject client1_2;
    public GameObject client1_3;

    public GameObject client2_1;
    public GameObject client2_2;
    public GameObject client2_3;

    public GameObject client3_1;
    public GameObject client3_2;
    public GameObject client3_3;

	public Vector3 posInitial;
	public Vector3 increment;

	// Cards:
	public GameObject[] cardMaterials;

	// Player parameters:
	public int gold;
	//public int attendedClient;
	public int MAX_CARDS;
	public int INITIAL_CARDS; 
	//Hand
	public List<GameObject> hand;

    //Audio
    public AudioSource aSourceClick;
    public AudioSource aSourceRepair;
    public AudioSource aSourceBuy;

    //Tiempo 
    public float time = 0f;
    public float MAX_TIME = 120;
	public Text timeText;


    // Use this for initialization
    void Start () {
		time = PlayerPrefs.GetInt("tiempo");
        //Initize materials card vector:
        cardMaterials = new GameObject[9];
        //goldText = GameObject.FindObjectOfType<Text>();
		cardMaterials[0] = GameObject.Find("Cloth");
		cardMaterials[1] = GameObject.Find("Cotton");
		cardMaterials[2] = GameObject.Find("Thread");
		cardMaterials[3] = GameObject.Find("Sheet");
		cardMaterials[4] = GameObject.Find("Wood");
		cardMaterials[5] = GameObject.Find("Gear");
		cardMaterials[6] = GameObject.Find("Leather");
		cardMaterials[7] = GameObject.Find("Plastic");
		cardMaterials[8] = GameObject.Find("Porcelain");
		clientsAttended = 0;
        goldText.text = gold.ToString();

		//Initize materials card vector:
		this.initHand();
        client1.GetComponent<Client>().generateClient();
        client2.GetComponent<Client>().generateClient();
        client3.GetComponent<Client>().generateClient();


	}

	//función para incicializar mazo:
	void initHand(){
		GameObject tmp;
		System.Random random = new System.Random();
		hand = new List<GameObject>();
		for (int i = 0; i < INITIAL_CARDS; ++i) {
			tmp = cardMaterials [random.Next (0, 9)];
			hand.Add(Instantiate(tmp, posInitial, Quaternion.identity));
            //posInitial += increment;
		}
        Reordenar();
    }

	//Función para inicializar clientes:
	void initClients(){
		client1 = GameObject.Find ("Client1");
		client2 = GameObject.Find ("Client2");
		client3 = GameObject.Find ("Client3");
	}

    public void repairObject(GameObject client, GameObject card)
    {
		Client cliente;
		TMaterial carta_cliente;

        //Comprobar si estado de nuestra carta es roto o no
        if (card.gameObject.GetComponent<TMaterial>().status == 1)
            return;
		if (!client) {
			print ("Cliente null");
			return;
		}
		cliente = client.gameObject.GetComponent<Client> ();
		print (cliente);
		carta_cliente = cliente.card1.gameObject.GetComponent<TMaterial> ();

		if (carta_cliente.status == 1)
        {
            if (card.gameObject.GetComponent<TMaterial>().type == client.gameObject.GetComponent<Client>().card1.gameObject.GetComponent<TMaterial>().type)
            {
                client.gameObject.GetComponent<Client>().card1.gameObject.GetComponent<TMaterial>().status = 0;
                client.gameObject.GetComponent<Client>().card1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                card.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.980f, 0.502f, 0.447f, 1f);
                card.gameObject.GetComponent<TMaterial>().status = 1;
                client.gameObject.GetComponent<Client>().isAll();
                return;
            }
        }

        if (client.gameObject.GetComponent<Client>().card2.gameObject.GetComponent<TMaterial>().status == 1)
        {
            if (card.gameObject.GetComponent<TMaterial>().type == client.gameObject.GetComponent<Client>().card2.gameObject.GetComponent<TMaterial>().type)
            {
                client.gameObject.GetComponent<Client>().card2.gameObject.GetComponent<TMaterial>().status = 0;
                client.gameObject.GetComponent<Client>().card2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                card.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.980f, 0.502f, 0.447f, 1f);
                card.gameObject.GetComponent<TMaterial>().status = 1;
                client.gameObject.GetComponent<Client>().isAll();
                return;
            }
        }

        if (client.gameObject.GetComponent<Client>().card3.gameObject.GetComponent<TMaterial>().status == 1)
        {
            if (card.gameObject.GetComponent<TMaterial>().type == client.gameObject.GetComponent<Client>().card3.gameObject.GetComponent<TMaterial>().type)
            {
                client.gameObject.GetComponent<Client>().card3.gameObject.GetComponent<TMaterial>().status = 0;
                client.gameObject.GetComponent<Client>().card3.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                card.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.980f, 0.502f, 0.447f, 1f);
                card.gameObject.GetComponent<TMaterial>().status = 1;
                client.gameObject.GetComponent<Client>().isAll();
                return;
            }
        }
    }
    public void Reordenar()
    {
        for(int i = 0; i<hand.Count; i++)
        {
            hand[i].transform.position = posInitial + increment * i;
        }
    }
    public void redoCard(int repairIndex,GameObject card)
    {
        print("REPAIRINDEX-->" + repairIndex);
        if (repairIndex==1&&repair_collider1.GetComponent<DetectCard>().isFull == true)
        {
            repair1 = card;
            Debug.Log("Carta Repair1 -> " + repair1);
        }
        if (repairIndex == 2&&repair_collider2.GetComponent<DetectCard>().isFull == true)
        {
            repair2 = card;
            Debug.Log("Carta Repair2 -> " + repair2);
        }
        if (repair_collider1.GetComponent<DetectCard>().isFull && repair_collider2.GetComponent<DetectCard>().isFull)
        {
            if(repair1.GetComponent<TMaterial>().type == repair2.GetComponent<TMaterial>().type)
            {
                hand.Remove(repair1.gameObject);
                hand.Remove(repair2.gameObject);

                hand.Add(Instantiate(cardMaterials[repair1.GetComponent<TMaterial>().type], posInitial, Quaternion.identity));
                gold -= repair1.GetComponent<TMaterial>().repairPrice;
                goldText.text = gold.ToString();
                DestroyObject(repair1.gameObject);
                DestroyObject(repair2.gameObject);
                
                repair1 = null;
                repair2 = null;
 
                repair_collider1.GetComponent<DetectCard>().isFull = false;
                repair_collider2.GetComponent<DetectCard>().isFull = false;
                Debug.Log("Collider1-> " + repair_collider1.GetComponent<DetectCard>().isFull);
                Debug.Log("Collider2-> " + repair_collider2.GetComponent<DetectCard>().isFull);

                aSourceRepair.Play();

                Reordenar();
            }
        }

        Debug.Log("Collider1-> " + repair_collider1.GetComponent<DetectCard>().isFull);
        Debug.Log("Collider2-> " + repair_collider2.GetComponent<DetectCard>().isFull);
    }

    public void buyCard(int name)
    {
		int materialPrice = cardMaterials[name].GetComponent<TMaterial>().buyPrice;
		if (materialPrice > gold)
			return;
		
        if (hand.Count < MAX_CARDS)
        {
            hand.Add(Instantiate(cardMaterials[name], posInitial, Quaternion.identity));
            gold -= cardMaterials[name].GetComponent<TMaterial>().buyPrice;
            aSourceBuy.Play();
            if (gold < 0)
                gold = 0;
            goldText.text = gold.ToString();
            Reordenar();
        }
    }

    //Activar audio con el click
    public void OnMouseDown()
    {
        aSourceClick.Play();
    }
    //Acabar juego
    public void GameOver() {
		Puntuacion ();
        //SceneManager.LoadScene("GameOver");
		GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>().LoadScene("GameOver");
            
    }

	void Puntuacion() {
		int points = clientsAttended * 10 + gold;
		PlayerPrefs.SetInt ("totalPoints", points);
		PlayerPrefs.SetInt ("clientsAttended", clientsAttended);
		PlayerPrefs.SetInt ("totalGold", gold);
	}

    // Update is called once per frame
    void Update () {
		time -= Time.deltaTime;
		Debug.Log (time);
		if (time <= 0.0f) {
			GameOver ();
		}
		timeText.text = ((int)time).ToString ();

		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameObject.FindGameObjectWithTag ("Fade").GetComponent<Fade> ().LoadScene ("Menu");

		}
	}
}
