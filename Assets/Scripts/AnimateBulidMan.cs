using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBulidMan : MonoBehaviour
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
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.02f, gameObject.transform.localScale.z);

        if (frame == 10)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.02f, gameObject.transform.localScale.z);

        if (frame == 20)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.02f, gameObject.transform.localScale.z);
        if (frame == 30)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.02f, gameObject.transform.localScale.z);

        if (frame == 40)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.02f, gameObject.transform.localScale.z);

        if (frame == 50)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.02f, gameObject.transform.localScale.z);

        if (frame == 60)
            frame = -1;
        frame++;
    }
}
