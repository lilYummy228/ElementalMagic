using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void Stop() => 
        Time.timeScale = 0f;

    public void Start() => 
        Time.timeScale = 1f;
}
