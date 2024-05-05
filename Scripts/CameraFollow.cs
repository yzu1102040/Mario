using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private void Awake() {
        Target=GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    private void LateUpdate() {
        Vector3 cameraPos = transform.position;
        cameraPos.x=Mathf.Max(cameraPos.x,Target.position.x);
        transform.position = cameraPos;
    }
}
