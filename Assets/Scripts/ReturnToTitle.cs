using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{

    public float timeToWait = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("Title");
    }
}
