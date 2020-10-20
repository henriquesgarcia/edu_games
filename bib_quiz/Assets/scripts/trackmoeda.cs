using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class trackmoeda : MonoBehaviour
{

    public GameObject[] obstacles;
    public Vector2 numberOfObstacles;
    public List<GameObject> newObstacles;
    public float speed;
    private float x;
    private int posicao;
    private float y;
    public float rateSpawn;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {

        int newNumberOfObstacles = (int)UnityEngine.Random.Range(numberOfObstacles.x, numberOfObstacles.y);
        for (int i = 0; i < newNumberOfObstacles; i++)
        {
            newObstacles.Add(Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], transform));
            newObstacles[i].SetActive(false);

        }

        PositionateObstacles();
    }
    void Update()
    {
        x = transform.position.x;
        x += speed * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (x <= -17)
        {
            Destroy(transform.gameObject);
        }
        if (currentTime >= rateSpawn)
        {
            currentTime = 0;
            posicao = UnityEngine.Random.Range(1, 100);
            if (posicao > 50)
            {
                y = -8.53f;
            }
            else

            {
                y = -9.4f;
            }

        }
    }
    // Update is called once per frame
    void PositionateObstacles()
    {
        for (int i = 0; i < newObstacles.Count; i++)
        {
            float posZmin = (0.37f / newObstacles.Count) + (0.37f / newObstacles.Count) * i;
            float posZmax = (0.37f / newObstacles.Count) + (0.37f / newObstacles.Count) * i + 1;
            newObstacles[i].transform.localPosition = new Vector3(transform.position.x, y, UnityEngine.Random.Range(posZmin, posZmax));
            newObstacles[i].SetActive(true);
        }
    }
}
