using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Slider _musicSlidef, _sfxSlider;

    public void _MusicVolume(float volume)
    {
        AudioManager.Instance.MusicVolume(_musicSlidef.value);
    }
    public void _SFXVolume(float volume)
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
    public void _ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void _ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
}
