using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{

    private int idTema;
    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text infoRespostas;

    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] corretas;

    private int idPerguntas;

    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;
    public Text tempoText;
    private float tempo = 20;



    // Start is called before the first frame update
    void Start()
    {
        //pegar o valor do tema
        idTema = PlayerPrefs.GetInt("idTema");
        idPerguntas = 0;
        questoes = perguntas.Length;

        pergunta.text = perguntas[idPerguntas];
        respostaA.text = alternativaA[idPerguntas];
        respostaB.text = alternativaB[idPerguntas];
        respostaC.text = alternativaC[idPerguntas];

        infoRespostas.text = "Respondendo " + (idPerguntas + 1).ToString() + " de " + questoes.ToString() + " questões.";


    }
    public void resposta(string alternativa)
    {

        if (alternativa == "A")
        {
            if (alternativaA[idPerguntas] == corretas[idPerguntas])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "B")
        {
            if (alternativaB[idPerguntas] == corretas[idPerguntas])
            {
                acertos += 1;
            }
        }
        else if (alternativa == "C")
        {
            if (alternativaC[idPerguntas] == corretas[idPerguntas])
            {
                acertos += 1;
            }
        }


        proximaPergunta();
    }

    public void Update()
    {

        if (tempo > 0)
        {//se o tempo menor que 0
            tempo -= Time.deltaTime;//subtrai do Time.deltaTime.int 
            int tempoTexto = (int)tempo;//converte o valor float para int
            tempoText.text = "Tempo: " + tempoTexto.ToString();// configura o textpara o texto Tempo: 10
        }
        if (tempo <= 0)
        {
            proximaPergunta();
        }

    }

    void proximaPergunta()
    {
        idPerguntas += 1;
        if (idPerguntas <= (questoes - 1))
        {
            pergunta.text = perguntas[idPerguntas];
            respostaA.text = alternativaA[idPerguntas];
            respostaB.text = alternativaB[idPerguntas];
            respostaC.text = alternativaC[idPerguntas];

            infoRespostas.text = "Respondendo " + (idPerguntas + 1).ToString() + " de " + questoes.ToString() + " questões.";

        }
        else
        {

            media = 10 * (acertos / questoes);
            notaFinal = Mathf.RoundToInt(media);
            //IF NOTA FINAL DA JOGADA > QUE A NOTA JOGADA ANTERIORMENTE,  SERÁ GRAVADO O NOVO RECORDE
            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {
                //gravados quando bate o record
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);

            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);

            SceneManager.LoadScene("notaJogo");

        }


    }


}
