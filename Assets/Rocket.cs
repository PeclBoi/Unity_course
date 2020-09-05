using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    RocketsSoundeffect rocketsSoundeffect;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        rocketsSoundeffect = new RocketsSoundeffect(GetComponent<AudioSource>());
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
            rocketsSoundeffect.StartThrustSoundeffect();
            ThrustRocket();
        }
        else {
            rocketsSoundeffect.StopThrustSoundeffect();
        }
    }


    private void RotateLeft() {
        transform.Rotate(Vector3.forward);
    }

    private void RotateRight() {
        transform.Rotate(Vector3.back);
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
