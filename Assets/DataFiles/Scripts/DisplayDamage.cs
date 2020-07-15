using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Image splashImage;

    private void Start()
    {
        splashImage.gameObject.SetActive(false);
    }
    public void DisplayDamageUI()
    {
       StartCoroutine(DisplaySplashImage());
    }

    public IEnumerator DisplaySplashImage()
    {
        splashImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        splashImage.gameObject.SetActive(false);
    }
}
