using System.Collections;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(nameof(pang));
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator pang()
    {
        yield return new WaitForSeconds(2);
        Instantiate(GameManager.Instance.bloodsplatters[Random.Range(0, GameManager.Instance.bloodsplatters.Length)], 
            transform.position, Quaternion.Euler(90, Random.Range(0, 360), 0));
        gameObject.SetActive(false);
    }
}
