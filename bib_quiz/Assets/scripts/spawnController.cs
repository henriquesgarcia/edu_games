using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    public GameObject obsPrefab;
    public float rateSpawn;
    public float currentTime;
    private int posicao;
    private float y;
    public float speed;
    private float x;
    public List<GameObject> newObstacles;
    public Vector2 numberOfObstacles;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        int newNumberOfObstacles = (int)UnityEngine.Random.Range(numberOfObstacles.x, numberOfObstacles.y);
        for (int i = 0; i < newNumberOfObstacles; i++)
        {
            newObstacles.Add(Instantiate(obsPrefab, transform));
            newObstacles[i].SetActive(false);

        }
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

        currentTime += Time.deltaTime;
        if(currentTime >= rateSpawn)
        {
            currentTime = 0;
            posicao = UnityEngine.Random.Range(1,100);
            if (posicao > 50)
            {
                y = -2.53f;
            }
            else

            {
                y = -3.53f;
            }
            
            
            GameObject tempPrefab = Instantiate(obsPrefab) as GameObject;
            tempPrefab.transform.position = new Vector3(transform.position.x, y, tempPrefab.transform.position.z);
   
        }
    }
}
