using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private Image _loadingBar;
    [SerializeField] private Text _loadingText;

    private void Start()
    {
        SceneController.Instance.AutoCallNextScene(this);
    }

    public void UpdateUI(float progress)
    {
        _loadingText.text = Mathf.Round(progress * 100).ToString();// *100 ya que es de 0 a 1
        _loadingBar.fillAmount = progress; //fillAmount sólo sirve si la imagen está seteada como Type.Filled
    }
}
