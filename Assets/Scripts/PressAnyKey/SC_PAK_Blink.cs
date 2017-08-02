using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class SC_PAK_Blink : MonoBehaviour {

    [SerializeField]
    private string PAK;
    [SerializeField]
    private Text thetext;
    //
 
    //
    private bool isTyping = false;

    private bool cancelTyping = false;
    //0.3125f
    private float TypeSpeed = 3.0f;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

     
        //
        if (Input.anyKeyDown)
        {
            cancelTyping = true;
            StartCoroutine(SwapScene(2));
        }
    }

    #region SwapScene
    IEnumerator SwapScene(int SC_Index, float time = 1.5f)
    {
        yield return new WaitForSeconds(1.5f);
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        Application.LoadLevel(SC_Index);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
    }

    #endregion
}
