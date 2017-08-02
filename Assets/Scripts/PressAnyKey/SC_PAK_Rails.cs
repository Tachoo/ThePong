using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum PlayMode
{
    linear,
    catmull,
}

[ExecuteInEditMode]
public class SC_PAK_Rails : MonoBehaviour {

    #region Variables
    public Transform[] nodes;

    #endregion
    // Use this for initialization
    void Start ()
    {
        //Obtenemos la referencia de los nodos;
        nodes = GetComponentsInChildren<Transform>(); //Hasta el padre lo toma
	}




    #region Interpolate
    //Modo en el que se va a 
    public Vector3 PositionOnRail(int seg, float ratio,PlayMode mode)
    {
        switch (mode)
        {
            case PlayMode.linear:
                return Linearposition(seg,ratio);
                break;
            case PlayMode.catmull:
                return Catmullposition(seg, ratio);
                break;
            default:
                return Linearposition(seg, ratio);
                break;
        }
    }
    //Obtenemos la interpolacion de dos vectores en R3(n y n+1)
    #region linearpsition
    public Vector3 Linearposition(int seg,float ratio)
    {
        Vector3 p1 = nodes[seg].position;
        Vector3 p2 = nodes[1+seg].position;

        return Vector3.Lerp(p1, p2, ratio);
    }
    #endregion
    //Obtenemos la interpolacion de do  Quaterniones (n y n+1)
    #region Rotarion
    public Quaternion Orientation(int seg, float ratio)
    {
        Quaternion q1 = nodes[seg].rotation;
        Quaternion q2 = nodes[1 + seg].rotation;

        return Quaternion.Lerp(q1, q2, ratio);
    }
    #endregion
    //CatMullCurve
    public Vector3 Catmullposition(int seg, float ratio)
    {
        Vector3 p1, p2, p3, p4;
        if (seg == 0)
        {
            p1 = nodes[seg].position;
            p2 = p1;
            p3 = nodes[seg+1].position;
            p4 = nodes[seg+2].position;
        }
        else if (seg == nodes.Length - 2)
        {
            p1 = nodes[seg - 1].position;
            p2 = nodes[seg].position;
            p3 = nodes[seg + 1].position;
            p4 = p3;
        }
        else
        {
            p1 = nodes[seg - 1].position;
            p2 = nodes[seg].position;
            p3 = nodes[seg + 1].position;
            p4 = nodes[seg + 2].position; ;
        }
        float t2 = ratio * ratio;

        float t3 = t2 * ratio;
        //X
        float Cat_X = 0.5f * ((2.0f * p2.x) + (-p1.x + p3.x) *ratio + (2.0f * p1.x - 5.0f * p2.x + 4 * p3.x - p4.x) * t2 + (-p1.x + 3.0f * p2.x - 3.0f * p3.x + p4.x) * t3);
        //Y
        float Cat_y = 0.5f * ((2.0f * p2.y) + (-p1.y + p3.y) * ratio + (2.0f * p1.y - 5.0f * p2.y + 4 * p3.y - p4.y) * t2 + (-p1.y + 3.0f * p2.y - 3.0f * p3.y + p4.y) * t3);
        //Z
        float Cat_Z = 0.5f * ((2.0f * p2.z) + (-p1.z + p3.z) * ratio + (2.0f * p1.z - 5.0f * p2.z + 4 * p3.z - p4.z) * t2 + (-p1.z + 3.0f * p2.z - 3.0f * p3.z + p4.z) * t3);
        //
        return new Vector3(Cat_X,Cat_y,Cat_Z);
        //
    }
    #endregion
    #region Gizmos
    private void OnDrawGizmos()
    {
        for(int i = 0; i < nodes.Length - 1; i++)
        {
            Handles.DrawDottedLine(nodes[i].position, nodes[1 + i].position, 3.0f);
        }
        
    }
    #endregion
}
