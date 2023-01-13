using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraFollowController : MonoBehaviour
{

    [SerializeField] private Transform heroTransform;

    private Vector3 offset;
    private Vector3 newPosition;

    [SerializeField] private float lerpValue;
    void Start()
    {
        offset = transform.position - heroTransform.position;
    }
    
    void LateUpdate()
    {
        setCameraSmoothFollow();
    }

    private void setCameraSmoothFollow()
    {
        newPosition = Vector3.Lerp(transform.position, new Vector3(0f, heroTransform.position.y, heroTransform.position.z) + offset, lerpValue * Time.deltaTime); // Only follow y and z
        transform.position = newPosition;
    }
}
