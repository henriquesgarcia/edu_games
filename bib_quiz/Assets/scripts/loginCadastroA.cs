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
using System.Globalization;


public class loginCadastroA : MonoBehaviour
{

    public InputField InputUserL;
    public InputField InputSenhaL;
    public GameObject txt_error;
    public GameObject txt_user_senha;

    private string userL;
    private string senhaL;
    IDbConnection sqlcon;
    IDbCommand dbcmd;
    IDbConnection dbconn;
    private string conn;
    private IDataReader reader;
    string sql;
    string filepath;
    private string dbfile = "URI=FILE:MySQLITEDB.db";
    private string dbfilen =" MySQLITEDB.db";

    public void Start()
    {

       // filepath = Application.dataPath + "/" + dbfile;
        //  filepath = Application.persistentDataPath + "" + dbfile;
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


        txt_error.SetActive(false);
        txt_user_senha.SetActive(false);

        //open db connection
        conn = "URI=file:MySQLITEDB.db";

        UnityEngine.Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();


    }

    public void Login(string cena)
    {

        userL = InputUserL.text.ToString();
        senhaL = InputSenhaL.text.ToString();



        try
        {
            if ((userL == "") && (senhaL == "") || (userL == "") || (senhaL == ""))
            {

                txt_error.SetActive(true);


            }

            else
            {
                try
                {
                    dbconn.Open(); //Open connection to the database.
                    dbcmd = dbconn.CreateCommand();
                    string query = "SELECT * FROM ALUNO WHERE user='" + userL + "' AND senha= '" + senhaL + "' ";
                    dbcmd.CommandText = query;
                    dbcmd.ExecuteNonQuery();
                    reader = dbcmd.ExecuteReader();
                    int count = 0;

                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        SceneManager.LoadScene(cena);


                    }


                    if (count < 1)
                    {
                        txt_user_senha.SetActive(true);
                    }
                }
                catch (IOException e)
                {

                }

            }


        }
        catch (IOException e)
        {

        }

    }





}
