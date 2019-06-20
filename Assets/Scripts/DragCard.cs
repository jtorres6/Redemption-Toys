using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour {

    public AudioSource aSource;
	Vector3 pos;
	Vector3 pos_inicial;
    public GameObject GameObjectAux;
    public GameObject gameController;
	// Use this for initialization
	void Start () {
		pos_inicial = transform.position;
		pos = pos_inicial;
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void OnMouseEnter(){
		//print ("Pincho");
	}
	private void OnMouseDrag(){
        aSource.Play();
		Vector3 tmp = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
		tmp.z = -1;
		transform.position = tmp;

	}

	private void OnMouseUp(){
        /*Vector3 tmp = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D r = Physics2D.Linecast(Camera.main.transform.position,tmp);

        Debug.DrawLine(Camera.main.transform.position, tmp, Color.red);*/
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity,1<<8);
        if (hit.collider!=null)
        {
            //print(r);
            print(hit.collider.gameObject.name);

            if (hit.collider.gameObject.tag=="repara")
            {
                if (GameObjectAux.GetComponent<DetectCard>().isFull == false
                    && this.GetComponent<TMaterial>().status == 1)
                {
                    GameObjectAux.GetComponent<DetectCard>().isFull = true;
                    GameObjectAux.GetComponent<DetectCard>().SavedCard = gameObject;
                    string aux = GameObjectAux.name.Substring(0, 1);
                    int repairIndex = int.Parse(aux);
                    gameController.GetComponent<GameController>().redoCard(repairIndex, this.gameObject);
                    print("Relleno el " + repairIndex);
                    return;
                }
            }
            else
            {
                //print(GameObjectAux.name);
                gameController.GetComponent<GameController>().repairObject(GameObjectAux, this.gameObject);
            }
        }

        /*if (GameObjectAux != null && GameObjectAux.tag == "repara")
        {
            

            
        }
        else if (GameObjectAux != null)
        {
            
        }
        else
        {
            print(GameObjectAux);
        }*/
        transform.position = pos;
        gameController.GetComponent<GameController>().Reordenar();
	}
}
