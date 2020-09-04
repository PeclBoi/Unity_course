using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

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
        print("rotate right");
    }
    private void ThrustRocket() {
        print("Thrusting");
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
