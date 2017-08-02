using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PAK_MovRails : MonoBehaviour {

    public SC_PAK_Rails rail;
    [SerializeField]
    private bool isreversed;
    [SerializeField]
    private bool islooping=true;
    //
    private int currentseg;
    private float transition;
    private bool IsComplete;
    [SerializeField]
    private bool toloop=true;
    [SerializeField]
    private float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (!rail)
        {
            return;
        }
        if (!IsComplete)
        {
            MoveRails(!isreversed);
        }
	}

    private void MoveRails(bool foward = true)
    {
        // f(t) 1/X;
        float m = (rail.nodes[currentseg + 1].position - rail.nodes[currentseg].position).magnitude;
        float s = (Time.deltaTime * 1 / m)* speed;
        transition += (foward) ? s : -s;
        //transition += Time.deltaTime * 1 / TimeToComplete;
        if (transition > 1)
        {
            transition = 0;
            currentseg++;
            if (currentseg == rail.nodes.Length - 1)
            {
                if (islooping)
                {
                    if (toloop)
                    {
                        transition = 1;
                        currentseg = rail.nodes.Length - 2;
                        isreversed = !isreversed;

                    }
                    else
                    {
                        currentseg = 0;
                    }

                }
                else
                {
                    IsComplete = true;
                    return;
                }
            }
        }
        else if(transition<0)
        {
            transition = 1;
            currentseg--;
            if (currentseg == - 1)
            {
                if (islooping)
                {
                    if (toloop)
                    {
                        transition = 0;
                        currentseg = 0;
                        isreversed = !isreversed;

                    }
                    else
                    {
                        currentseg = rail.nodes.Length-2;
                    }

                }
                else
                {
                    IsComplete = true;
                    return;
                }
            }
        }
        //
        //transform.position = rail.Linearposition(currentseg, transition);
        transform.position = rail.Catmullposition(currentseg, transition);
        transform.rotation = rail.Orientation(currentseg, transition);
    }
}
