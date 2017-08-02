using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    #region VarSection
    [SerializeField]
    float VelocityMultp; // Velocidad!
    //
    [SerializeField]
    public bool inicio;
    //
    [SerializeField]
    Transform[] FirePoint;
    //
    private Rigidbody P_RigBody;
    #endregion

    void Awake()
    {
        P_RigBody = GetComponent<Rigidbody>();
        //
        FirePoint = GetComponentsInChildren<Transform>();
    }

    void Start ()
    {

      

    }
    private void LateUpdate()
    {
        if (inicio == true && Singleton.instance.GameIsReady != true) //Si esta false  pues no hace nada
        {
            Singleton.instance.GameStart += InstanceBall; // Agregamos a la lista la funcion
            Singleton.instance.GameIsReady = true;
        }
    }
    void Update ()
    {
      

        if (Singleton.instance.Win == 0)
        {
            #region Arriba,Abajo
            // vec3(0,0,1)
            if (Input.GetKey(KeyCode.Keypad8))
            {
                P_RigBody.velocity = new Vector3(0, 0, 1) * VelocityMultp * (Time.deltaTime);
            }
            // vec3(0,0,-1)
            if (Input.GetKey(KeyCode.Keypad2))
            {
                P_RigBody.velocity = new Vector3(0, 0, -1) * VelocityMultp * (Time.deltaTime);
            }
            #endregion
        }

    }
    void InstanceBall()
    {
        //Instancea la pelotita desde la carpeta de Recursos
        Instantiate<GameObject>(Resources.Load("Ball") as GameObject, FirePoint[1].position, Quaternion.identity);
    }


}
