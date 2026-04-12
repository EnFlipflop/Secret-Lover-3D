using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [NonSerialized] public Movement3D movement3D;
    [NonSerialized] public Camera3D camera3D;

    [NonSerialized] public bool interacting;
    
    private static GameManager instance;
    
    public TextMeshProUGUI letterText;
    public int talkedTo;

    public int letterInt;
    public int ciggHints = 3;
    public RawImage ciggVisual;
    public Texture[] ciggSprites;
    public LetterScriptable[] letters;
    public Person[] guests;
    public GameObject[] bloodsplatters;
    public ResultScriptable result;
    public TextMeshProUGUI hintCounter;
    [Header("Character identifiers")]
    [Header("Dick Allford = 1")]
    [Header("Robert Wrong = 2")]
    [Header("Frank too frank Frank = 3")]
    [Header("Lawrence Douglaws = 4")]
    [Header("Ann Phayqename = 5")]
    [Header("Rose Monroe = 6")]
    [Header("Charles Dandy = 7")]
    [Header("Robert Left = 8")]
    [Space(5)]
    public string endOfInspector;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (movement3D == null)
        {
            movement3D = player.GetComponentInChildren<Movement3D>();
        }
        
        if (camera3D == null)
        {
            camera3D = player.GetComponentInChildren<Camera3D>();
        }
        PickLetter();
        letterText.text = letters[letterInt].LetterText;
        letterText.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        hintCounter.text = ciggHints.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            CiggHint();
    }

    public void StopInteracting()
    {
        interacting = false;
    }

    private void PickLetter()
    {
        letterInt = Random.Range(0, letters.Length);
        letterText.text = letters[letterInt].LetterText;
        result.letter = letterInt;
    }

    public void CiggHint()
    {
        Debug.Log("CiggHint");
        if (ciggHints > 0)
        { 
            ciggHints--;
            hintCounter.text = ciggHints.ToString();
            foreach (Person person in guests)
            {
                person.Die(letters[letterInt].hintKills[ciggHints]);
            }
            
        }
        ciggVisual.texture = ciggSprites[ciggHints];
    }

    public void Guess(int identifier)
    {
        result.win = identifier == letters[letterInt].rightAnswer;
        //ladda scen
    }
}
