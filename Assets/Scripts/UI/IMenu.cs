using UnityEngine;

interface IMenu
{
    Transform MenuPanel { get; }

    public void Open(Transform menuPanel);
}
