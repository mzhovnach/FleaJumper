using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _rigidbody;
    private float _speed;

	// Use this for initialization
	void Start () {
        _speed = 1.0f;
        _rigidbody.velocity = new Vector2(_speed, 0.0f);
	}

    //direction should be -1 or 1
    public void SetRandomSpeed(float direction)
    {
        _speed = Random.Range(0.1f, 0.2f) * direction;
        _rigidbody.velocity = new Vector2(_speed, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetDogSpeed()
    {
        return _speed;
    }
}
