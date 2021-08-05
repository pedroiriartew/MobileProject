using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScript : MonoBehaviour
{
    [SerializeField] private float _timeRemaining = 5f;
    [SerializeField] private Text _text;

    // Update is called once per frame
    void Update()
    {
        _timeRemaining -= Time.deltaTime;
        _text.text = "Se va en: " + ((int)_timeRemaining).ToString();

        if (_timeRemaining <=0)
        {
            SceneController.Instance.CallScene("Menu");
        }
    }
}
