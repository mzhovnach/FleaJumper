using System;
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
    private Vector3 _direction;
    private Vector3 _startDragPoint;

    public Action OnBeginDrag;
    public Action<Vector3> OnUpdateDrag;
    public Action<Vector3> OnEndDrag;

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
                _startDragPoint = Input.mousePosition;
                // begin drag
                if (OnBeginDrag != null)
                {
                    OnBeginDrag();
                }
            }
        }
        else if (_state == InputState.Dragging)
        {
            _direction = (_startDragPoint - Input.mousePosition);
            _direction.x /= (float)Screen.width;
            _direction.y /= (float)Screen.height;
            if (!Input.GetMouseButton(0))
            {
                // finish drag
                if (OnEndDrag != null)
                {
                    OnEndDrag(_direction);
                }
                _state = InputState.Idle;
            }
            else
            {
                // update drag
                if (OnUpdateDrag != null)
                {
                    OnUpdateDrag(_direction);
                }
            }
        }
	}
}
