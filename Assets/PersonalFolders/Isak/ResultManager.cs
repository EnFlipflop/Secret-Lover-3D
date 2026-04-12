using System;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Texture l1w, l1l, l2w, l2l, l3w, l3l;
    public ResultScriptable result;
    public RawImage bild;
    private void Awake()
    {
        if (result.letter == 1)
        {
            if (result.win)
                bild.texture = l1w;
            else bild.texture = l1l;
        }
        if (result.letter == 2)
        {
            if (result.win)
                bild.texture = l2w;
            else bild.texture = l2l;
        }
        if (result.letter == 3)
        {
            if (result.win)
                bild.texture = l3w;
            else bild.texture = l3l;
        }
        
    }
}
