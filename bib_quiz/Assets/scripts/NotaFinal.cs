using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NotaFinal : MonoBehaviour
{
    private int idTema;

    public Text txtNota;
    public Text txtInfoTema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;
    private int acertos;
    private int notaF;
    public int qtd_perguntas;

    // Start is called before the first frame update
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");

        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());

        txtNota.text = notaF.ToString();
        txtInfoTema.text = "Você acertou " + acertos.ToString() + " de " + qtd_perguntas.ToString() + " questões.";

        if (notaF == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);

        }
        else if (notaF >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
        }
        else if (notaF >= 5)
        {
            estrela1.SetActive(true);
        }

    }
    public void jogarNovamente()
    {
        SceneManager.LoadScene("jogo");

    }

}
