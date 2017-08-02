using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;


//MultiPropocito
public class Singleton : MonoBehaviour
{
    #region Set Up Singleton
    //Esta es la perte privada que nadie tiene acceso fuera de este script 
    private static Singleton _instance;
    // API Entry 
    public static Singleton instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject crossScenes = new GameObject("singleton");
                crossScenes.AddComponent<Singleton>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        //Debemos de indicar que no se destruya por que todo lo que contenga se ira al GC
        DontDestroyOnLoad(this.gameObject);
        _instance = this; //Para no perder la referencia a este GameObject
    }

    #endregion

    #region Menu




    #endregion
    //No tocar hasta que este las mecanicas principales

    #region Creditos

    #endregion
    // No tocar hasta que  tengamos los menus terminados

    #region Game
    public int GetPlayer()
    {
        // La semilla de C# es diferente a la de C++  pero en terminos generales es lo mismo
        System.Random rand = new System.Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        return rand.Next(2);
    }

    public bool GameIsReady { get; set; }
    public int  Win { get; set; }
    //Creamos la delegacion
    public delegate void PlayerTurn();
    public PlayerTurn GameStart;
    #endregion
    // Antes de cualquier cosa terminar las menicanicas principales

    



}
