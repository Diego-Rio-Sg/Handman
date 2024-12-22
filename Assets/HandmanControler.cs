using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;
using System.Threading;



public class HangmanController : MonoBehaviour
{

    [SerializeField] GameObject WordContainer;
    [SerializeField] GameObject KeyBoardContainer;
    [SerializeField] GameObject LetterContainer;
    [SerializeField] GameObject[] HangmanStages;
    [SerializeField] GameObject LetterButton;
    [SerializeField] TextAsset possibleword;

    [SerializeField] GameObject WordTemaContainer;
    [SerializeField] GameObject WordTemaLetterContainer;
    [SerializeField] TextAsset WordMusica;
    [SerializeField] TextAsset WordComida;
    [SerializeField] TextAsset WordPais;
    [SerializeField] TextAsset WordMarca;
    [SerializeField] TextAsset WordAnimal;
    [SerializeField] TextAsset WordDeporte;
    [SerializeField] TextAsset WordObjeto;


    NEnt Num;
    Vector v1Music;
    Vector v2Comida;
    Vector v3Pais;
    Vector v4Marca;
    Vector v5Animal;
    Vector v6Deporte;
    Vector v7Objeto;
    Cadena Tema;

    private string word;    
    private int incorrectGuesses, correctGuesses; 
    private int Wins,Defeats;
    public Text WinsText;
    public Text DefeatsText;


    void Start()
    {
        Num = new NEnt();

        v1Music = new Vector();
        v2Comida = new Vector();
        v3Pais = new Vector();
        v4Marca = new Vector();
        v5Animal = new Vector();
        v6Deporte = new Vector();
        v7Objeto = new Vector();
        Wins = 0;
        Defeats = 0;
        Tema = new Cadena();

        InitialiseButtons();
        InitialiseGame();
    }




    // #1        Botones de Inicializacion
    private void InitialiseButtons()
    {
        for (int i = 65; i <= 90; i++)
        {
            CreateButton(i);
        }
    }

    //    #  6 Inicializacion de anulacion privada
    private void InitialiseGame()
    {
        incorrectGuesses = 0;
        correctGuesses = 0;
        foreach (Button child in KeyBoardContainer.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }
        foreach (Transform child in WordContainer.GetComponentsInChildren<Transform>())
        {
            if (child != WordContainer.transform)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in WordTemaContainer.GetComponentsInChildren<Transform>())
        {
            if (child != WordTemaContainer.transform)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (GameObject stage in HangmanStages)  
        {
            stage.SetActive(false);
        }
        //generate new word  
        word = generateword().ToUpper();

        foreach (char letter in word)
        {
            var temp = Instantiate(LetterContainer, WordContainer.transform);
        }
        //string s = Tema.Descargar();
        Tema.ToUpTrim();
        foreach (char i in Tema.Descargar())
        {
            var temp = Instantiate(WordTemaLetterContainer, WordTemaContainer.transform);
            temp.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();   
        }

    }
    // # 2       Crear un boton 
    private void CreateButton(int i)
    {
        GameObject temp = Instantiate(LetterButton, KeyBoardContainer.transform);
        temp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        temp.GetComponent<Button>().onClick.AddListener(delegate { CheckLetter(((char)i).ToString()); });
    } 
    // # 5
    private string generateword()
    {
        Num.CargarRandom(1, 7 + 1);
        string[] wordList = possibleword.text.Split("\n");

        // CATEGORIA MUSICA
        if (Num.Descargar() == 1)
        {
            wordList = WordMusica.text.Split("\n");
            Tema.Cargar(wordList[0]);
            if (v1Music.DimV() == wordList.Length - 1)
            {
                v1Music.ResetV(); 
                Num.CargarRandom(1, wordList.Length);
                v1Music.CargarNum(Num.Descargar());

            }
            else
            {
                Num.CargarRandom(1, wordList.Length);
                while (v1Music.XenVector(Num.Descargar()))
                {
                    Num.CargarRandom(1, wordList.Length);
                }
            }


        }
        //CATEGORIA COMIDA
        else if (Num.Descargar() == 2)
        {
            wordList = WordComida.text.Split("\n");
            Tema.Cargar(wordList[0]);


            if (v2Comida.DimV() == wordList.Length - 1)
            {
                v2Comida.ResetV(); 
                Num.CargarRandom(1, wordList.Length);
                v2Comida.CargarNum(Num.Descargar());
            }
            else
            {
                Num.CargarRandom(1, wordList.Length);
                while (v2Comida.XenVector(Num.Descargar()))
                {
                    Num.CargarRandom(1, wordList.Length);
                }
            }
        }
        //CATEGORIA PAIS
        else if (Num.Descargar() == 3)
        {
            wordList = WordPais.text.Split("\n");
            Tema.Cargar(wordList[0]);


            if (v3Pais.DimV() == wordList.Length - 1)
            {
                v3Pais.ResetV();  
                Num.CargarRandom(1, wordList.Length);
                v3Pais.CargarNum(Num.Descargar());

            }
            else
            {
                Num.CargarRandom(1, wordList.Length);
                while (v3Pais.XenVector(Num.Descargar()))
                {
                    Num.CargarRandom(1, wordList.Length);
                }
            }
        }
        //CATEGORIA MARCA
        else if (Num.Descargar() == 4)
        {
            wordList = WordMarca.text.Split("\n");
            Tema.Cargar(wordList[0]);


            if (v4Marca.DimV() == wordList.Length - 1)
            {
                v4Marca.ResetV(); 
                Num.CargarRandom(1, wordList.Length);
                v4Marca.CargarNum(Num.Descargar());

            }
            else
            {
                Num.CargarRandom(1, wordList.Length);
                while (v4Marca.XenVector(Num.Descargar()))
                {
                    Num.CargarRandom(1, wordList.Length);
                }
            }
        }
        // CATEGORIA ANIMAL
        else if (Num.Descargar() == 5)
        {
            wordList = WordAnimal.text.Split("\n");
            Tema.Cargar(wordList[0]);


            if (v5Animal.DimV() == wordList.Length - 1)
            {
                v5Animal.ResetV(); 
                Num.CargarRandom(1, wordList.Length);
                v5Animal.CargarNum(Num.Descargar());

            }
            else
            {
                Num.CargarRandom(1, wordList.Length);
                while (v5Animal.XenVector(Num.Descargar()))
                {
                    Num.CargarRandom(1, wordList.Length);
                }
            }
        }
        // CATEGORIA DEPORTE
        else if (Num.Descargar() == 6)
        {
            wordList = WordDeporte.text.Split("\n");
            Tema.Cargar(wordList[0]);


            if (v6Deporte.DimV() == wordList.Length - 1)
            {
                v6Deporte.ResetV();  
                Num.CargarRandom(1, wordList.Length);
                v6Deporte.CargarNum(Num.Descargar());

            }
            else
            {
                Num.CargarRandom(1, wordList.Length);
                while (v6Deporte.XenVector(Num.Descargar()))
                {
                    Num.CargarRandom(1, wordList.Length);
                }
            }
        }
        // CATEGORIA OBJETO
        else if (Num.Descargar() == 7)
        {
            wordList = WordObjeto.text.Split("\n");
            Tema.Cargar(wordList[0]);


            if (v7Objeto.DimV() == wordList.Length - 1)
            {
                v7Objeto.ResetV();  
                Num.CargarRandom(1, wordList.Length);
                v7Objeto.CargarNum(Num.Descargar());

            }
            else
            {
                Num.CargarRandom(1, wordList.Length);
                while (v7Objeto.XenVector(Num.Descargar()))
                {
                    Num.CargarRandom(1, wordList.Length);
                }
            }
        }
        string line = wordList[Num.Descargar()];
        return line.Trim();
    }





    // # 3       Carta de Verificacion (string   Letra de entrada)
    private void CheckLetter(string inputLetter)
    {
        bool LetterInWord = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (inputLetter == word[i].ToString())
            {
                LetterInWord = true;
                correctGuesses++; 
                WordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = inputLetter;
            }
        }

        if (!LetterInWord)
        {
            incorrectGuesses++;

            if (incorrectGuesses <= word.Length)
            {
                HangmanStages[incorrectGuesses - 1].SetActive(true);
            }
        }
        CheckOutcome();
    }

    //  # 4     Verificar resultado
    private void CheckOutcome()
    {
        if (correctGuesses == word.Length) 
        {
            Wins++;
            WinsText.text = Wins.ToString();
            for (int i = 0; i < word.Length; i++)
            {
                WordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.green;
                
            }
            Invoke("InitialiseGame", 1f);
            
        }
        else if (incorrectGuesses == HangmanStages.Length)
        {
            Defeats++;
            DefeatsText.text = Defeats.ToString();
            for (int i = 0; i < word.Length; i++)
            {
                WordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.red;
                WordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = word[i].ToString();
                
            }
            Invoke("InitialiseGame", 1f);
        }
    }
}

