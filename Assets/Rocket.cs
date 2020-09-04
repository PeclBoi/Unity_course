using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
   
    Rigidbody rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        ProcessInput();
    }


    private void ProcessInput() {

        if (RocketDirection.isRotatingLeft()) {
            RotateLeft();
        }
        else if (RocketDirection.isRotatingRight()) {
            RotateRight();
        }
        if (RocketDirection.isThrusting()) {
            ThrustRocket();
        }
    }

    private void RotateLeft() {
        print("rotate left");
    }
    private void RotateRight() {
        rigidBody.AddRelativeForce(Vector3.right);
    }
    private void ThrustRocket() {
        rigidBody.AddRelativeForce(Vector3.up);
    }
}

public class RocketDirection {
    public static bool isRotatingLeft() {
        return Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);
    }
    public static bool isRotatingRight() {
        return Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A);
    }
    public static bool isThrusting() {
        return Input.GetKey(KeyCode.Space);
    }
}
