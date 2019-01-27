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
    private AudioSource _audioSuurce;
    private BoxCollider2D _collider;
    private Dog _prevDog;
    private float _flyingTime;
    public SpriteRenderer Renderer;
    public Action<Dog> OnFleaWantsToAttachToDog;
    public Action OnFleaStoppedWithoutDog;
    public GameObject Arrow;

    private void Awake()
    {
        _state = State.Attached;
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _audioSuurce = GetComponent<AudioSource>();
        Arrow.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Renderer.sortingOrder = -(int)((transform.position.y) * 100.0f);
        Renderer.sortingOrder += 1;
        if (_state == State.Flying)
        {
            _flyingTime += Time.deltaTime;
            if (_flyingTime > 1.0f && OnFleaStoppedWithoutDog != null && _rigidBody.velocity.magnitude < 1.0f)
            {
                _rigidBody.velocity = Vector2.zero;
                OnFleaStoppedWithoutDog();
                _state = State.Dead;
            }
        }
    }

    public void AttachToDog(Dog dog)
    {
        _state = State.Attached;
        transform.SetParent(dog.transform);
        transform.localPosition = Vector3.zero;
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.simulated = false;
        _prevDog = dog;
        _audioSuurce.Play();
        dog.SetFleaOnDog(true);
    }

    public void JumpIntoDirection(Vector2 direction)
    {
        _flyingTime = 0.0f;
        _state = State.Flying;
        _rigidBody.simulated = true;
        _rigidBody.AddForce(direction * 1500.0f);
        Renderer.GetComponent<AudioSource>().Play();
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

    public bool CanJump()
    {
        return _state == State.Attached;
    }

    public void SetArrowVisible(bool visible)
    {
        if (Arrow)
        {
            Arrow.gameObject.SetActive(visible);
            Arrow.transform.localScale = Vector3.zero;
        }
    }

    public void SetArrowDirection(Vector3 direction)
    {
        if (Arrow)
        {
            Arrow.transform.localScale = new Vector3(1.0f, direction.magnitude * 50.0f, 1.0f);
            Arrow.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }
    }
}
