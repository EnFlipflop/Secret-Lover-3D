using System;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Texture winBack, loseBack, Anne, Dick, Frank;
    public ResultScriptable result;
    public RawImage bild, bakgrund;
    private void Awake()
    {
        if (result.letter == 1)
        {
            bild.texture = Anne;
        }
        if (result.letter == 2)
        {
            bild.texture = Dick;
        }
        if (result.letter == 3)
        {
            bild.texture = Frank;
        }
        if (result.win)
            bakgrund.texture = winBack;
        else
        {
            bakgrund.texture = loseBack;
        }
        
    }
}
