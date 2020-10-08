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
public class listarTurma : MonoBehaviour
{
    private IDbConnection connection;

    private IDbCommand command;
    private string conn, sqlQuery;

    IDbConnection dbconn;

    IDbCommand dbcmd;

    private IDataReader reader;
    private string dbfile = "URI=FILE:MySQLITEDB.db";
    private string filepath;
    private string dbfilen = " MySQLITEDB.db";
    //private List<turma> turmas = new List<turma>();
    [SerializeField]
    public GameObject buttonTemplate;
    private string nome;
    public Text nomeTurma;
    private string nomeTurmas;
    // Start is called before the first frame update
    void Start()
    {
        filepath = string.Format("{0}/{1}", Application.persistentDataPath, dbfilen);

        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            UnityEngine.Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" + Application.dataPath + "!/MySQLITEDB");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/MySQLITEDB.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }

        //open db connection
        conn = "URI=file:MySQLITEDB.db";

        UnityEngine.Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();
        GetTurmas1();



    }

    void GetTurmas1()
    {
        using (IDbConnection dbConnection = new SqliteConnection(conn))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())

            {
                string sqlQuery = "SELECT * FROM TURMA";

                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        nomeTurma.text = nomeTurmas;
                        nomeTurmas = reader.GetString(2);
                        GameObject button = Instantiate(buttonTemplate) as GameObject;
                        button.SetActive(true);
                        button.transform.SetParent(buttonTemplate.transform.parent, false);
                        button.GetComponentInChildren<Text>().text = nomeTurmas;
                    }




                }

                dbConnection.Close();
                reader.Close();

            }
        }
    }


}
