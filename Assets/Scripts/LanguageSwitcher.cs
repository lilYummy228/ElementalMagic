using Lean.Localization;
using UnityEngine;
using YG;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;
    [SerializeField] private LeanLanguage[] _leanLanguages;

    private void Start()
    {
        if (YandexGame.savesData.Language == default)
            SwitchLanguage(YandexGame.EnvironmentData.language);
    }

    public void SwitchLanguage(string language)
    {
        foreach (LeanLanguage leanLanguage in _leanLanguages)
        {
            if (language == leanLanguage.TranslationCode)
            {
                _leanLocalization.SetCurrentLanguage(leanLanguage.Cultures[0]);
                YandexGame.SwitchLanguage(language);
            }
        }

        YandexGame.savesData.Language = language;
        YandexGame.SaveProgress();
    }
}
