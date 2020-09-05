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
        UpdateMovement();
        UpdateRocketSoundEffects();
    }

    private void UpdateMovement() {
        RotateRocket();
        MoveRocketIfThrusting();
    }


    private void RotateRocket() {

        rigidBody.freezeRotation = true;

        setEulerAngleRotationXAndYTo(0, 0);
        if (RocketDirection.isRotatingLeft()) {
            RotateLeft();
        }
        else if (RocketDirection.isRotatingRight()) {
            RotateRight();
        }

        rigidBody.freezeRotation = false;
    }

    //TODO review name later
    private void setEulerAngleRotationXAndYTo(int x, int y) {
        gameObject.transform.eulerAngles = new Vector3(
            x,
            y,
            gameObject.transform.eulerAngles.z
            );
    }

    private void RotateLeft() {
        transform.Rotate(Vector3.forward);
    }

    private void RotateRight() {
        transform.Rotate(Vector3.back);
    }

    private void MoveRocketIfThrusting() {
        if (RocketDirection.isThrusting()) {
            rigidBody.AddRelativeForce(Vector3.up);
        }
    }

    private void UpdateRocketSoundEffects() {
        ThrustingSoundeffect();
    }

    private void ThrustingSoundeffect() {
        if (RocketDirection.isThrusting()) {
            rocketsSoundeffect.StartThrustSoundeffect();
        }
        else {
            rocketsSoundeffect.StopThrustSoundeffect();
        }
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
