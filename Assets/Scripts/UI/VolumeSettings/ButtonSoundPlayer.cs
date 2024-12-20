using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundPlayer : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private ButtonSoundData _buttonSoundData;

    public void OnPointerClick(PointerEventData eventData) =>
        _buttonSoundData.AudioSource.PlayOneShot(_buttonSoundData.ClickClip);

    public void OnPointerEnter(PointerEventData eventData) =>
        _buttonSoundData.AudioSource.PlayOneShot(_buttonSoundData.EnterClip);
}
