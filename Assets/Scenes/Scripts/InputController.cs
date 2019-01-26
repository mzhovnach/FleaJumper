using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    private enum InputState
    {
		Idle,
        Dragging
	}

    private InputState _state;

    public void OnBeginDrag()
    {

    }

    private void Awake()
    {
        _state = InputState.Idle;
    }

    // Update is called once per frame
    void Update () {
        if (_state == InputState.Idle)
        {
            if (Input.GetMouseButton(0))
            {
                _state = InputState.Dragging;
                // begin drag
            }
        }
        else if (_state == InputState.Dragging)
        {
            if (!Input.GetMouseButton(0))
            {
                // finish drag
            }
            else
            {
                // update drag
            }
        }
	}
}
