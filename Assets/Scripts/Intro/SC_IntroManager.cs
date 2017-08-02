using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_IntroManager : MonoBehaviour
{
    #region SectionVariables
    // 
    public Image FrontGround;
    //
    public Text TheCampusGame;
    //
    public string Auto;
    //
    private bool isTyping = false;

    private bool cancelTyping = false;
    //0.3125f
    private float TypeSpeed = 0.23f;


    #endregion
    // Use this for initialization
    void Start()
    {
        OnDissolve(FrontGround, 0.0f, 3.5f);
        StartCoroutine(Wait(Auto));

    }
    // Update is called once per frame
    void Update()
    {
        //
        if (Input.anyKeyDown)
        {
            cancelTyping = true;
            StartCoroutine(SwapScene(1));
        }
    }

    #region GUI Dissolve
    void OnDissolve(Image ToDissolve, float Alpha, float Duration, bool IgnoreTimescale = false)
    {
        ToDissolve.CrossFadeAlpha(Alpha, Duration, IgnoreTimescale);
        //

    }
    #endregion
    #region SyncDissolve
    IEnumerator Wait(string auto)
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(AutoType(auto));
    }
    #endregion
    #region AutoType
    IEnumerator AutoType(string lineoftext)
    {
        int letter = 0;
        TheCampusGame.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineoftext.Length - 1))
        {
            TheCampusGame.text += lineoftext[letter];
            letter += 1;
            yield return new WaitForSeconds(TypeSpeed);
        }
        TheCampusGame.text = lineoftext;
        isTyping = false;
        cancelTyping = false;
        StartCoroutine(SwapScene(1, 0.5f));
    }
    #endregion
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
