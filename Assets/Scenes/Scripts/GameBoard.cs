using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public SmoothCamera2D CameraFollower;
    public BackgroundScroller BackgroundScroller;
    private Dog _dogHost;
    public DogSpawner DogSpawner;
    public InputController InputController;
    public Flea Flea;
    public GameObject WorldObject;

    private float _timer = 0.0f;
    private float _spawnTime = 4.0f;

	// Use this for initialization
	void Start () {
        //create first dog
        _dogHost = null;
        Dog newDogHost = DogSpawner.SpawnRandomDog();
        newDogHost.transform.position = Vector3.zero;
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

    }

    private void OnUpdateDrag(Vector3 direction)
    {

    }

    private void OnEndDrag(Vector3 direction)
    {
        Debug.Log("OnEndDrag: " + direction);
        Flea.transform.SetParent(WorldObject.transform, true);
        Flea.JumpIntoDirection(direction);
        CameraFollower.target = Flea.transform;
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
        Debug.Log("GAMEOVER");
    }
}
