using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScript : MonoBehaviour
{
    [SerializeField] private float _timeRemaining = 5f;

    // Update is called once per frame
    void Update()
    {
        _timeRemaining -= Time.deltaTime;

        if (_timeRemaining <=0)
        {
            SceneController.Instance.CallScene("Menu");
        }
    }
}
