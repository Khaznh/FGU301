using UnityEngine;

[CreateAssetMenu(fileName = "FishStats", menuName = "Scriptable Objects/FishStats")]
public class FishStats : ScriptableObject
{
    public GameObject fishPrefap;
    public float fishSpeed;
    public float fishChangeDirTimer;
    public float lostProgress;
    public float gainsProgress;
}
