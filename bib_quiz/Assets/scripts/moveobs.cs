using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobs : MonoBehaviour
{
    private float x;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            x = transform.position.x;
            x += speed * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            if (x <= -17)
            {
                Destroy(transform.gameObject);
            }

        
    }
}
