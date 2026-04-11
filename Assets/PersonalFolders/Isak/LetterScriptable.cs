using UnityEngine;
[CreateAssetMenu(fileName = "LetterObject", menuName = "LetterObject", order = 1)]
public class LetterScriptable : ScriptableObject
{
    [TextArea(15,20)]
    public string LetterText;
    public int rightAnswer;
    public int[] hintKills;
}
