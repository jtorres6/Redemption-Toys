using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateRobot : MonoBehaviour
{

    public int frame = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (frame == 0)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, gameObject.transform.position.z);

        if (frame == 10)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, gameObject.transform.position.z);

        if (frame == 20)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, gameObject.transform.position.z);
        if (frame == 30)
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, gameObject.transform.position.z);

        if (frame == 40)
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, gameObject.transform.position.z);

        if (frame == 50)
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, gameObject.transform.position.z);

        if (frame == 60)
            frame = -1;
        frame++;
    }
}
