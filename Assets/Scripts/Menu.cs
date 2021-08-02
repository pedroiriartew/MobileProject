using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{    public void LoadFirstLevel()
    {
        SceneController.Instance.CallScene("FirstLevel");
    }
}
