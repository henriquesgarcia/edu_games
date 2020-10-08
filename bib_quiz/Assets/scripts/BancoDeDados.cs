using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
using System.Diagnostics;

public class BancoDeDados : MonoBehaviour
{


    private IDbConnection connection;
    private IDbCommand command;
    private IDataReader reader;

    private string dbfile = "URI=FILE:MySQLITEDB.db";
   
    void Start()
    {
       


    }
    private  void Connection()
    {
        connection = new SqliteConnection(dbfile);
        command = connection.CreateCommand();
        connection.Open();
      // string Drop = "DROP TABLE IF EXISTS quiz";
       string tableUser = "CREATE TABLE IF NOT EXISTS user( id INTEGER PRIMARY KEY AUTOINCREMENT, nome VARCHAR(70),user VARCHAR(10),senha PASSWORD );";
       string tableQuiz = "CREATE TABLE IF NOT EXISTS quiz( id INTEGER PRIMARY KEY AUTOINCREMENT,id_user INTEGER NOT NULL,perguntas VARCHAR(500) NOT NULL,alt_A VARCHAR(500),alt_B VARCHAR(500),alt_C VARCHAR(500),alt_D VARCHAR(500),resposta_correta VARCHAR(1),temas VARCHAR(500),FOREIGN KEY ('id_user') REFERENCES 'user'('id') );";
        string querya = "CREATE TABLE IF NOT EXISTS aluno (ID INTEGER PRIMARY KEY   AUTOINCREMENT, nome varchar(100), user varchar(200), senha password (8)";
        command.CommandText = tableUser;
        command.CommandText = tableQuiz;
        command.CommandText = querya;

        command.ExecuteNonQuery();

    
    }
    public void InsertUser()
    { 
        string query = "INSERT INTO user(nome,email,user,senha) VALUES('joao guilherme','joaoguilherme@hotmail.com','joao','1234');"
            + "INSERT INTO user(nome,email,user,senha) VALUES('marcos Bisneto','marcos@gmail.com','marcos','1234')";
        command.CommandText = query;
        command.ExecuteNonQuery();


    }


   /* private void insertPergunta(int id_prof, string tema ,int qtd_pergunta, string pergunta, string altA, string altB, string altC, string altD, string resposta_correta )
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into quiz ( id_user,qtdPerguntas,perguntas,alt_A,alt_B,alt_C,alt_D,resposta_correta,temas) values (\"{0}\",\"{1}\",\"{2}\")", id_prof, tema, qtd_pergunta,pergunta,altA,altB,altC,altD,resposta_correta);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }*/

    //public void UpdateColumn()
    //{

    //}

    //public void InsertOrUpdate()
    //{

    //}

    public void ConsultOne()
    {
        int id2 = 2;
        string query = "SELECT id,nome,email,user,senha FROM user WHERE id = " + id2 + ";";
        command.CommandText = query;
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string nome = reader.GetString(1);
            string email = reader.GetString(2);
            string user = reader.GetString(3);
            string senha = reader.GetString(4);

            print("id: " +id+"nome: "+nome+" user: "+user+" senha: "+senha);

        }




    }
    public void ConsultAll()
    {
        string query = "SELECT id,nome,email,user,senha FROM user ;";
        command.CommandText = query;
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string nome = reader.GetString(1);
            string email = reader.GetString(2);
            string user = reader.GetString(3);
            string senha = reader.GetString(4);

            print("id: " + id + "nome: " + nome + " user: " + user + " senha: " + senha);

        }





    }

    public void Delete()
    {
        int id = 2;
        string query = "DELETE FROM user WHERE id = " + id + ";";
        command.CommandText = query;
        command.ExecuteNonQuery();

    }



}
