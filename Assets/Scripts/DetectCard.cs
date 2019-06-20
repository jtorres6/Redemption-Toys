using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCard : MonoBehaviour {
    public bool isFull;
    public GameObject SavedCard;
    // Use this for initialization
    void Start() {
        isFull = false;
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter2D(Collider2D col) {
            
        if (col.tag == "Card"){
                Debug.Log("Hay carta-->" + col.name);
                col.gameObject.GetComponent<DragCard>().GameObjectAux = this.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Card")
        {

            if (gameObject.tag == "repara")
            {
                if (col.gameObject == SavedCard)
                {
                    isFull = false;
                    Debug.Log("Ha salido la carta -->" + col.name);
                }


            }
            else
            {
                if (col.gameObject.GetComponent<DragCard>().GameObjectAux == gameObject)
                {

                    col.gameObject.GetComponent<DragCard>().GameObjectAux = null;
                }
            }


        }
    }
}
