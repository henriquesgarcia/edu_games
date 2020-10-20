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

public class cadastrar_perguntas : MonoBehaviour
{
    private IDbConnection connection;

    private IDbCommand command;
    private string conn, sqlQuery;

    IDbConnection dbconn;

    IDbCommand dbcmd;

    public SqliteDataReader dataread;

    private IDataReader reader;
    public InputField InputTema;
    public InputField InputPergunta;
    public InputField InputAltA;
    public InputField InputAltB;
    public InputField InputAltC;
    public InputField InputAltD;
    public InputField InputResCorreta;
    public InputField Inputnome;
    public InputField Inputuser;
    public InputField Inputsenha;
    public InputField InputDesc;
    public InputField InputDisc;
    public GameObject txt_error;
   



    //private int idProfessor;
    private string Tema;
    private string Pergunta;
    private string alternativaA;
    private string alternativaB;
    private string alternativaC;
    private string alternativaD;
    private string RespostaCorreta;

    private string nome;
    private string user;
    private string senha;
    private int idProfessor;
    private string togAluno;
    private string togProf;
    private string dbfile = "URI=FILE:MySQLITEDB.db";
    private string filepath;
    private string dbfilen = " MySQLITEDB.db";
    private string descricao;
    private string disciplina;
    private float tempo = 2.0f;
    private float cronometro = 0.0f;
    private bool aviso = false;


    void Start()
    {

       // filepath = Application.dataPath + "/" + dbfile;
        //filepath = Application.persistentDataPath + "/" + dbfile;
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
        // txt_error.SetActive(false);


    }

    private void createTable()
    {
        connection = new SqliteConnection(conn);
        connection.Open();

        string query = "CREATE TABLE IF NOT EXISTS user (ID INTEGER PRIMARY KEY   AUTOINCREMENT, nome varchar(100), user varchar(200), senha password (8)";
        string querya = "CREATE TABLE IF NOT EXISTS aluno (ID INTEGER PRIMARY KEY   AUTOINCREMENT, nome varchar(100), user varchar(200), senha password (8)";
        string tableQuiz = "CREATE TABLE IF NOT EXISTS quiz( id INTEGER PRIMARY KEY AUTOINCREMENT,id_user INTEGER NOT NULL,perguntas VARCHAR(500) NOT NULL,alt_A VARCHAR(500),alt_B VARCHAR(500),alt_C VARCHAR(500),alt_D VARCHAR(500),resposta_correta VARCHAR(1),temas VARCHAR(500),FOREIGN KEY ('id_user') REFERENCES 'user'('id') );";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            dbcmd.CommandText = tableQuiz;
            dbcmd.CommandText = querya;
            dbcmd.ExecuteNonQuery();


            // execute command which returns a reader
        }
        catch (IOException e)
        {

            UnityEngine.Debug.Log(e);

        }

    }

    public void InserirPerguntas()
    {
        int idUser = 2;
        idProfessor = 2;
       
        UnityEngine.Debug.Log(idProfessor);


        Tema = InputTema.text.ToString();
        Pergunta = InputPergunta.text.ToString();
        alternativaA = InputAltA.text.ToString();
        alternativaB = InputAltB.text.ToString();
        alternativaC = InputAltC.text.ToString();
        alternativaD = InputAltD.text.ToString();
        RespostaCorreta = InputResCorreta.text.ToString();
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("INSERT INTO quiz(id_user,perguntas,alt_A,alt_B,alt_C,alt_D,resposta_correta,temas) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\")", idProfessor, Pergunta, alternativaA, alternativaB, alternativaC, alternativaD, RespostaCorreta, Tema);
            UnityEngine.Debug.Log(sqlQuery);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }

        UnityEngine.Debug.Log("Insert Done  ");
        SceneManager.LoadScene("criarquiz");




    }



    public void CadastroUserP()
    {
      

        nome = Inputnome.text.ToString();
        user = Inputuser.text.ToString();
        senha = Inputsenha.text.ToString();
       
      
    
 
    
        using (dbconn = new SqliteConnection(conn))
            {
           
                dbconn.Open(); //Open connection to the database.
                dbcmd = dbconn.CreateCommand();
                sqlQuery = string.Format("insert into user (nome,user,senha) values (\"{0}\",\"{1}\",\"{2}\")", nome, user,senha);// table name
                UnityEngine.Debug.Log(sqlQuery);
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
           
        }

            UnityEngine.Debug.Log("Insert Done  ");

    }
    public void CadastroUserA()
    {


        nome = Inputnome.text.ToString();
        user = Inputuser.text.ToString();
        senha = Inputsenha.text.ToString();





        using (dbconn = new SqliteConnection(conn))
        {

            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into aluno(nome,user,senha) values (\"{0}\",\"{1}\",\"{2}\")", nome, user, senha);// table name
            UnityEngine.Debug.Log(sqlQuery);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();

        }

        UnityEngine.Debug.Log("Insert Done  ");

    }

    public void CadastroTurma()
    {


        int id_user = 2;
        descricao = InputDesc.text.ToString();
        disciplina = InputDisc.text.ToString();






        using (dbconn = new SqliteConnection(conn))
        {

            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into turma(id_user,descricao,disciplina) values (\"{0}\",\"{1}\",\"{2}\")", id_user, descricao, disciplina);// table name
            UnityEngine.Debug.Log(sqlQuery);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            OnTriggerEnter();
            Ongui();

        }

       
            

        }
    


    void Update()
    {

        if (aviso == true)
        {
            cronometro += Time.deltaTime;
        }
        if (cronometro >= tempo)
        {
            aviso = false;
            txt_error.SetActive(false);
            SceneManager.LoadScene("cadTurma");
        }
       



    }
    void OnTriggerEnter()
    {
        aviso = true;
    }
    void Ongui()
    {
        if (aviso == true)
        {
            txt_error.SetActive(true);
            UnityEngine.Debug.Log("Insert Done  ");


        }
       


    }





}

