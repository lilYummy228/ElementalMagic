using UnityEngine;

public class Element : MonoBehaviour
{
    private float _resizeValue = 1.2f;

    public void Highlight(bool isSelected)
    {
        if (isSelected)
            transform.localScale /= _resizeValue;
        else
            transform.localScale *= _resizeValue;
    }
}
