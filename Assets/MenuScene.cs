using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

    private float timeElapsed = 0f;
    private float delayBeforeLoading = 3f;
    public string scene = "House";

    // Update is called once per frame
    void Update () {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= delayBeforeLoading)
            ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
