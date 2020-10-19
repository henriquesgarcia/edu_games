using System.Linq;
using System.IO;
using System.Data;
using Mono.Data.SqliteClient;
using System.Diagnostics;
using System.Data.SQLite;
using UnityEngine.SceneManagement;
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class RepetirChao : MonoBehaviour
{
    private GameController _gameController;
    bool _chaoinstanciado = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if(_chaoinstanciado == false)
        {
            if(transform.position.x <= 0)
            {
                _chaoinstanciado = true;
                GameObject ObjetoTemporarioChao = Instantiate(_gameController._chaoPrefab);
                ObjetoTemporarioChao.transform.position = new Vector3(transform.position.x + _gameController._chaoTamanho, transform.position.y, 0);
            }
        }
        if(transform.position.x < _gameController._chaoDestruido)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        transform.Translate(Vector2.left * _gameController._chaoVelocidade * Time.deltaTime);
    }

}
