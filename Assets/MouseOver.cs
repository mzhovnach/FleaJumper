using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseOver : MonoBehaviour {
    public GameObject btn;
    private int nowScene;

    public void Awake()
    {
        nowScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void playSound()
    {
        btn.GetComponent<AudioSource>().Play();
    }

    public void loadScene()
    {
        SceneManager.LoadScene(nowScene + 1);
    }
}
