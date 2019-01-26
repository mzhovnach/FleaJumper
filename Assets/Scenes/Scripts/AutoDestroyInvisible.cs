using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyInvisible : MonoBehaviour {

    void OnBecameInvisible()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
