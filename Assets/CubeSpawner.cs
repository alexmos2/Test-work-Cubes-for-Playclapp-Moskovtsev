using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject patternElement, button;
    GameObject cube;
    Rigidbody cube_rb;
    int delay, speed = 1, distance;
    [SerializeField]
    GameObject delayField, speedField, distanceField;
    public void StartSpawning()
    {
        if (Int32.TryParse (delayField.GetComponent<TMP_InputField>().text, out delay) &&
        Int32.TryParse (speedField.GetComponent<TMP_InputField>().text, out speed) &&
        Int32.TryParse (distanceField.GetComponent<TMP_InputField>().text, out distance))
        {
            if (delay > 0 && speed > 0 && distance > 0)
            {
                button.SetActive(false);
                delayField.SetActive(false);
                speedField.SetActive(false);
                distanceField.SetActive(false);
                InvokeRepeating(nameof(CreateCube), 0, delay);
            }
        }
    }
    void CreateCube()
    {
        cube = Instantiate<GameObject>(patternElement, new Vector3(20, 0, 12), transform.rotation);
        cube.GetComponent<Cube>().DestroyDelay = distance / speed;
        cube.GetComponent<Cube>().StartDelay();
        cube_rb = cube.GetComponent<Rigidbody>();
        cube_rb.velocity = Vector3.left * speed;
    }
}
