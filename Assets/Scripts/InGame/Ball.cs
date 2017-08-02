using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    #region varSection
    Rigidbody B_RigBody;
    [SerializeField]
    private float VelocityMultip;
    private Vector3 Direction;
    [SerializeField]
    private float Force;
    public bool Cnematic;
    #endregion

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
        Force = 500.0f;
        B_RigBody = GetComponent<Rigidbody>();
        Direction = new Vector3(1, 0, 1);
        B_RigBody.AddForce(Direction * Force);

    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    private void OnCollisionEnter(Collision other)
    {
        //Solo cambiamos la magnitus de la velocidad para crear el efecto de Rebote;
        // VelocityMultip = -VelocityMultip;

        //Direciones
        //Arriba
        if (other.collider.name == "Wall_1")
        {
            Direction = new Vector3(0,0,1);
            B_RigBody.AddForce(Direction * Force);
        }
        //Abajo
        if (other.collider.name == "Wall_2")
        {
            Direction = new Vector3(0,0,-1);
            B_RigBody.AddForce(Direction * Force);
        }
        //Izquierda
        if (other.collider.name == "Wall_3"&& Cnematic!=true)
        {
            Singleton.instance.Win = 2;
            this.gameObject.SetActive(false);
        }
        else
        {
            Direction = new Vector3(-1, 0, 0);
        }
        //Derecha
        if (other.collider.name == "Wall_4" && Cnematic != true)
        {
            Singleton.instance.Win = 1;
            this.gameObject.SetActive(false);
        }
        else
        {
            Direction = new Vector3(1, 0, 0);
        }
        //jugadores
        if (other.collider.name == "Player1")
        {
            int random = Random.Range(1, 3);
            if (random == 1)
            {
                Direction = new Vector3(1, 0, -1);
            }
            else if (random == 2)
            {
                Direction = new Vector3(1, 0, 0);
            }
            else
            {
                Direction = new Vector3(1, 0, 1);
            }

            
            B_RigBody.AddForce(Direction * Force);
        }
        if (other.collider.name == "Player2")
        {
            int random = Random.Range(1, 3);
            if (random == 1)
            {
                Direction = new Vector3(-1, 0, -1);
            }
            else if (random == 2)
            {
                Direction = new Vector3(-1, 0, 0);
            }
            else
            {
                Direction = new Vector3(-1, 0, 1);
            }
                B_RigBody.AddForce(Direction * Force);
        }
       
        
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
           B_RigBody.AddForce((Direction * Force)*Time.deltaTime*0.00001f);
        }
    }
}
