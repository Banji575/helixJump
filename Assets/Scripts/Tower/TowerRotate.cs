using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1.5f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                _rigidbody.AddTorque(Vector3.up * torque);
               // gameObject.transform.rotation = new Quaternion(0, torque, 0, 0);
            }
        }
    }
}
