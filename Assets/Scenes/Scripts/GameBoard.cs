using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public SmoothCamera2D CameraFollower;
    public BackgroundScroller BackgroundScroller;
    private Dog _dogHost;
    public DogSpawner DogSpawner;

	// Use this for initialization
	void Start () {
        //create first dog
        _dogHost = null;
        Dog newDogHost = DogSpawner.SpawnRandomDog();
        SetNewHost(newDogHost);
    }
	
	// Update is called once per frame
	void Update () {

	}


    public void SetNewHost(Dog newHostDog)
    {
        if (newHostDog != _dogHost)
        {
            _dogHost = newHostDog;
            BackgroundScroller.SetScrollSpeed(_dogHost.GetDogSpeed() / 2.0f);
            CameraFollower.target = _dogHost.transform;
        }
    }
}
