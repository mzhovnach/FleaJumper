using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LooseWindowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnRestartButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
