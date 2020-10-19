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

public class repetirCenario : MonoBehaviour
{
    private GameControllerC _gameControllerC;
    bool _cenarioinstanciado = false;

    // Start is called before the first frame update
    void Start()
    {
        _gameControllerC = FindObjectOfType(typeof(GameControllerC)) as GameControllerC;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cenarioinstanciado == false)
        {
            if (transform.position.x <= 0)
            {
                _cenarioinstanciado = true;
                GameObject ObjetoTemporarioCenario = Instantiate(_gameControllerC._cenarioPrefab);
                ObjetoTemporarioCenario.transform.position = new Vector3(transform.position.x + _gameControllerC._cenarioTamanho, transform.position.y, 0);
            }
        }
        if (transform.position.x < _gameControllerC._cenarioDestruido)
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
        transform.Translate(Vector2.left * _gameController._cenarioVelocidade * Time.deltaTime);
    }

}
