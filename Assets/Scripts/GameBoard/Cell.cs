using UnityEngine;

public class Cell : MonoBehaviour
{
    public Element Element { get; private set; }

    public void Set(Element element)
    {
        if (element != null)
            Element = element;
    }
}