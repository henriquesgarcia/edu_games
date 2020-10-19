using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;
using System.Data;
using Mono.Data.SqliteClient;
using System.Diagnostics;
using System.Data.SQLite;
using UnityEngine.SceneManagement;
using System.Threading;
using System;

public class LevelManager : MonoBehaviour
{

    public static LevelManager levelManager;
    private int moedasAtual = 0;
    private bool gameOver = false;
    private float segundos;
    private int segundosToInt;
    private int minutos;

    public Text minutosTxt;
    public Text segundosTxt;
    public Text moedasText;


    // Start is called before the first frame update
    void Awake()
    {
        if(levelManager == null)
        {
            levelManager = this;

        }
        else if(levelManager != this){
            Destroy(gameObject);
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            segundos += Time.deltaTime;
            if (segundos >= 60)
            {
                segundos = 0;
                minutos++;
                minutosTxt.text = minutos.ToString();
            }
            segundosToInt = (int)segundos;
            segundosTxt.text = segundosToInt.ToString();
        }
    }

    public void setMoedas()
    {
        moedasAtual++;
        moedasText.text = moedasAtual.ToString();
    }

    public int GetMoedas()
    {
        return moedasAtual;
    }
}

