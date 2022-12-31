using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisclaimerScreen : MonoBehaviour
{
    public float duration = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplayText(duration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisplayText(float duration)
    {
        yield return new WaitForSeconds(duration);

        GetComponent<SceneChanger>().GoToMainMenu();
    }
}
