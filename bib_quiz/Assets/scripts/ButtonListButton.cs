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

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    public Text myText;
    private string texto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void SetText()
    {
       
        myText.text = texto;

    }
    public void OnClick()
    {

    }
}
