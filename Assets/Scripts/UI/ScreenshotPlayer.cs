using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotPlayer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _screenshots;

    private WaitForSeconds _sleep;
    private int _sleepTime = 1;

    private void OnEnable()
    {
        _sleep = new(_sleepTime);

        StartCoroutine(nameof(Show));
    }

    private IEnumerator Show()
    {
        while (enabled)
        {
            foreach (Sprite screenshot in _screenshots)
            {
                _image.sprite = screenshot;

                yield return _sleep;
            }
        }
    }
}
