using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public SmoothCamera2D CameraFollower;
    public BackgroundScroller BackgroundScroller;
    private Dog _dogHost;
    public DogSpawner DogSpawner;

    private float _timer = 0.0f;
    private float _spawnTime = 10.0f;

	// Use this for initialization
	void Start () {
        //create first dog
        _dogHost = null;
        Dog newDogHost = DogSpawner.SpawnRandomDog();
        newDogHost.transform.position = Vector3.zero;
        newDogHost.SetSpeedMultiplier(0.1f);
        SetNewHost(newDogHost);
        _timer = _spawnTime;
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if (_timer >= _spawnTime)
        {
            _timer = 0.0f;
            DogSpawner.SpawnRandomDog();
        }

	}


    public void SetNewHost(Dog newHostDog)
    {
        if (newHostDog != _dogHost)
        {
            _dogHost = newHostDog;
            BackgroundScroller.SetScrollSpeed(_dogHost.GetDogSpeed() / 10.0f);
            CameraFollower.target = _dogHost.transform;
        }
    }
}
