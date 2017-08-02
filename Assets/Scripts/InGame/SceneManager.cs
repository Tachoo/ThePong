using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    #region VarSection
    [SerializeField]
    float TimeToContinue = 10.0f;
    [SerializeField]
    private bool Instance = false;
    [SerializeField]
    private int Turn;
    //
    [SerializeField]
    private bool Opcions;
    //
    private Player P1;
    private Player2 P2;
    //
    public GameObject UI;
    public GameObject Opciones;
    public GameObject WinGrid;
    //
    public Text TIME;
    public Text Message;
    //
    #endregion
    void Awake()
    {
        #region Obtener referencias
        //Objetenemos los componentes de una manera poco usual pero util para proyectos peque;os
        P1 = FindObjectOfType<Player>();
        //Comenzo la partida
        Singleton.instance.Win = 0;

        P2 = FindObjectOfType<Player2>();

        #endregion

        //Solo cuando inicia por primera vez el juego
        #region ObtenerTurno
        //Agarramos el numero del random
        Turn = 1 + Singleton.instance.GetPlayer();

        #endregion

    }
    void Start()
    {
        //Solo queda decirles quien es el que inicia primero

        #region Determinar turno
        if (Turn == 1)//Como sabemos que hay solo 2 numeros. podemos hacer esto;
        {
            P1.inicio = true; //Jugador 1 inicia
        }
        if (Turn == 2)//Como sabemos que hay solo 2 numeros. podemos hacer esto;
        {
            P2.inicio = true; //Jugador 1 inicia
        }
        #endregion
    }
    private void Update()
    {
        if (Singleton.instance.Win != 0)
        {
            //
            TimeToContinue -= Time.deltaTime;
            if (TimeToContinue < 1)
            {
                TimeToContinue = 0;
                //Go To main menu
                StartCoroutine(SwapScene(1,0.0f));

            }
        }
    }
    private void LateUpdate()
    {
        //Iniciar el duelo
        StartGame();
        //Pausa //Opciones
        OpcionsMenu();
        //Gano Alguien?
        WhoWins();
    }

    void StartGame()
    {
        if (Singleton.instance.GameIsReady != false && Input.GetKeyDown(KeyCode.Space) != false && Instance != true)
        {
            //Sabemos que es verdadero y entonces llamamos las delegaciones
            Singleton.instance.GameStart();
            Instance = true;
        }
        else
        {
            //No hacer nada
        }
    }
    void OpcionsMenu()
    {
        //Activar Desactivar el menu de Opciones;
        if (Input.GetKeyDown(KeyCode.Escape) && Singleton.instance.Win == 0)
        {
            Opcions = !Opcions;
            if (Opcions == true)
            {
                //Activamos el menu de opciones / pausa
                UI.SetActive(Opcions);
                Opciones.SetActive(Opcions);
            }
            else
            {
                //Desactivamos el menu de Opciones /Pausa
                UI.SetActive(Opcions);
                Opciones.SetActive(Opcions);
            }

        }
    }
    void WhoWins()
    {

        if (Singleton.instance.Win == 0)
        {

        }
        else
        {
            //Ya hay un ganador

            //Activamos los grids 
            UI.SetActive(true);
            WinGrid.SetActive(true);

            if (Singleton.instance.Win == 2)
            {
                //Gano y debemos de preguntar si quiere continuar;
                Message.text = "Player2 Wins!!";


            }
            else if (Singleton.instance.Win == 1)
            {
                //Gano y debemos de preguntar si quiere continuar;
                Message.text = "Player1 Wins!!";
            }
            else
            {
                //Nada
            }
            //Corre tiempo!!!

            TIME.text = "" + (int)TimeToContinue;

        }
    }

    IEnumerator SwapScene(int SC_Index, float time = 1.5f)
    {
        Singleton.instance.GameIsReady = true;
        Singleton.instance.Win = 0;
        yield return new WaitForSeconds(1.5f);
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        Application.LoadLevel(SC_Index);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
    }

}
