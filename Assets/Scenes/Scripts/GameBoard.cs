﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public SmoothCamera2D CameraFollower;
    public BackgroundScroller BackgroundScroller;
    public Dog _dogHost;
    public DogSpawner DogSpawner;
    public InputController InputController;
    public Flea Flea;
    public GameObject WorldObject;
    public LooseWindowController LooseWindow;
    public UIController uiController;

    private float _timer = 0.0f;
    private float _spawnTime = 2.0f;

	// Use this for initialization
	void Start () {
        //create first dog
        _dogHost = null;
        Dog newDogHost = DogSpawner.SpawnRandomDog();
        newDogHost.OnFleaDroppedFromDog = OnFleaDroppedFromDog;
        newDogHost.transform.position = Vector3.zero;
        newDogHost.UpdateSortingOrder();
        //newDogHost.SetSpeedMultiplier(0.1f);
        SetNewHost(newDogHost);
        _timer = _spawnTime;

        InputController.OnBeginDrag = OnBeginDrag;
        InputController.OnUpdateDrag = OnUpdateDrag;
        InputController.OnEndDrag = OnEndDrag;

        Flea.OnFleaWantsToAttachToDog = OnFleaWantsToAttachToDog;
        Flea.OnFleaStoppedWithoutDog = OnFleaStoppedWithoutDog;
    }

    private void OnBeginDrag()
    {
        if (Flea.CanJump())
        {
            Flea.SetArrowVisible(true);
        }
    }

    private void OnUpdateDrag(Vector3 direction)
    {
        Flea.SetArrowDirection(direction);
    }

    private void OnEndDrag(Vector3 direction)
    {
        Flea.SetArrowVisible(false);
        Debug.Log("OnEndDrag: " + direction);
        if (Flea.CanJump())
        {
            Flea.transform.SetParent(WorldObject.transform, true);
            Flea.JumpIntoDirection(direction);
            CameraFollower.target = Flea.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if (_timer >= _spawnTime)
        {
            _timer = 0.0f;
            Dog newDog = DogSpawner.SpawnRandomDog();
            newDog.OnFleaDroppedFromDog = OnFleaDroppedFromDog;
        }
        if (_dogHost)
        {
            uiController.SetParametres(_dogHost);
        }
    }

    public void SetNewHost(Dog newHostDog)
    {
        if (newHostDog != _dogHost)
        {
            if (_dogHost != null)
            {
                _dogHost.SetFleaOnDog(false);
            }
            _dogHost = newHostDog;
            CameraFollower.target = _dogHost.transform;
            Flea.AttachToDog(_dogHost);
        }
    }

    private void OnFleaWantsToAttachToDog(Dog dog)
    {
        SetNewHost(dog);
    }

    private void OnFleaStoppedWithoutDog()
    {
        GameOver();
    }

    private void OnFleaDroppedFromDog()
    {
        GameOver();
    }

    private void GameOver()
    {
        Debug.Log("GAMEOVER");
        LooseWindow.Show();
        CameraFollower.target = null;
    }
}
