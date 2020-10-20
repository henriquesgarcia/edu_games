using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mudarCena : MonoBehaviour
{
    // Start is called before the first frame update
    public void carregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);

    }
}
