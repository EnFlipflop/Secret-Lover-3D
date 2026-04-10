using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "CharacterObject", menuName = "CharacterObjects", order = 1)]
public class CharacterScriptable : ScriptableObject
{
    [SerializeField] public CharacterSystem characterSystem;
}
