using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flea : MonoBehaviour {

    private enum State
    {
        Attached,
        Flying,
        Dead
    }

    private State _state;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _collider;
    private Dog _prevDog;
    public SpriteRenderer Renderer;
    public Action<Dog> OnFleaWantsToAttachToDog;
    public Action OnFleaStoppedWithoutDog;

    private void Awake()
    {
        _state = State.Attached;
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Renderer.sortingOrder = -(int)(transform.position.y * 100.0f);
        if (_state == State.Flying && OnFleaStoppedWithoutDog != null && _rigidBody.velocity.magnitude < 1.0f)
        {
            OnFleaStoppedWithoutDog();
            _state = State.Dead;
        }
    }

    public void AttachToDog(Dog dog)
    {
        _state = State.Attached;
        transform.SetParent(dog.transform);
        transform.localPosition = Vector3.zero;
        _rigidBody.simulated = false;
        _prevDog = dog;
    }

    public void JumpIntoDirection(Vector2 direction)
    {
        _state = State.Flying;
        _rigidBody.simulated = true;
        _rigidBody.AddForce(direction * 1000.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        Dog dog = col.gameObject.GetComponent<Dog>();
        if (dog != null && dog != _prevDog && OnFleaWantsToAttachToDog != null)
        {
            OnFleaWantsToAttachToDog(dog);
        }
    }
}
