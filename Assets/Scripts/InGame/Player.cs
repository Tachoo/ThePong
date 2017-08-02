using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    #region VarSection

    [SerializeField]
    float VelocityMultp; // Velocidad!
    //
    [SerializeField]
   public  bool inicio;
    //
    private Rigidbody P_RigBody;

    [SerializeField]
    Transform[] FirePoint;

    #endregion
    // Todas las referencias se tienen que hacer en el Awake
    void Awake()
    {
        P_RigBody = GetComponent<Rigidbody>();
        FirePoint = GetComponentsInChildren<Transform>();
        
    }
    //Precalculos en el Start o traslaciones
    void Start()
    {

      
    }

    private void LateUpdate()
    {
        if (inicio == true && Singleton.instance.GameIsReady != true)
        {
            Singleton.instance.GameStart += InstanceBall; // Agregamos a la lista la funcion
            Singleton.instance.GameIsReady = true;
        }
        else
        {
            // por si algo queremos hacer
        }
    }
    // Update is called once per frame
    void Update ()
    {


        if (Singleton.instance.Win == 0)
        {
            #region Arriba,Abajo
            // vec3(0,0,1)
            if (Input.GetKey(KeyCode.W))
            {
                P_RigBody.velocity = new Vector3(0, 0, 1) * VelocityMultp * (Time.deltaTime);
            }
            // vec3(0,0,-1)
            if (Input.GetKey(KeyCode.S))
            {
                P_RigBody.velocity = new Vector3(0, 0, -1) * VelocityMultp * (Time.deltaTime);
            }
            #endregion
        }

    }
    /*Funcion que se encarga de instancear la pelota
     * pero no queremos tener la pelota dentro del entorno
     * ***************************************************
     * Podriamos cargarlo desde la carpeta de Recursos...
     * y el prefab estara seteado las velocidades etc...
    (La pelota tendra una velocidad Constante)*/
    /*Podemos hacer esta funcion una Funcion Delegada*/
    void InstanceBall()
    {
        //Instancea la pelotita desde la carpeta de Recursos
        Instantiate<GameObject>(Resources.Load("Ball") as GameObject, FirePoint[1].position, Quaternion.identity);
    }

}
