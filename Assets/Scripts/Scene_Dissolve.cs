using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scene_Dissolve : MonoBehaviour {

    #region SectionVariables
    // 
    public Image FrontGround;
    //
   


    #endregion
    // Use this for initialization
    void Start ()
    {
        OnDissolve(FrontGround, 0.0f, 3.5f);
        

    }
	// Update is called once per frame
	void Update ()
    {

       
        //
        if (Input.anyKeyDown)
        {
           
            StartCoroutine(SwapScene(2));
        }
    }

    #region GUI Dissolve
    void OnDissolve(Image ToDissolve, float Alpha, float Duration, bool IgnoreTimescale = false)
    {
        ToDissolve.CrossFadeAlpha(Alpha, Duration, IgnoreTimescale);
        //
      
    }

    IEnumerator SwapScene(int SC_Index, float time=1.5f)
    {
        yield return new WaitForSeconds(1.5f);
     #pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        Application.LoadLevel(SC_Index);
     #pragma warning restore CS0618 // El tipo o el miembro están obsoletos
    }
    #endregion

}
