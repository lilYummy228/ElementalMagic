using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI
{
    public class ScreenshotPlayer : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite[] _russianScreenshots;
        [SerializeField] private Sprite[] _englishScreenshots;
        [SerializeField] private Sprite[] _turkeyScreenshots;

        private WaitForSeconds _sleep;
        private int _sleepTime = 1;

        private void OnEnable()
        {
            _sleep = new (_sleepTime);

            StartShow();
        }

        private void StartShow()
        {
            switch (YandexGame.lang)
            {
                case "ru":
                    StartCoroutine(Show(_russianScreenshots));
                    break;

                case "en":
                    StartCoroutine(Show(_englishScreenshots));
                    break;

                case "tr":
                    StartCoroutine(Show(_turkeyScreenshots));
                    break;
            }
        }

        private IEnumerator Show(Sprite[] screenshots)
        {
            while (enabled)
            {
                foreach (Sprite screenshot in screenshots)
                {
                    _image.sprite = screenshot;

                    yield return _sleep;
                }
            }
        }
    }
}