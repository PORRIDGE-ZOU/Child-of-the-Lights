using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayTutorial());
        children = FindObjectsOfType<Tutorial>();
        children[1].GetComponent<SpriteRenderer>().enabled = true;
    }

    private Tutorial[] children;

    public IEnumerator DelayTutorial()
    {
        yield return new WaitForSeconds(10);
        children[0].GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(10);
        children[2].GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
