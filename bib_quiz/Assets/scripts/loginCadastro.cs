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


public class loginCadastro : MonoBehaviour
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
    string tglA;
    public void Start()
    {
        txt_error.SetActive(false);
        txt_user_senha.SetActive(false);

        conn = "URI=file:MySQLITEDB.db";
        dbconn = new SqliteConnection(conn);
        dbconn.Open();
        tglA = PlayerPrefs.GetString("status");
        UnityEngine.Debug.Log(tglA);

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
                    string query = "SELECT * FROM USER WHERE user='" + userL + "' AND senha= '" + senhaL + "' ";
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
