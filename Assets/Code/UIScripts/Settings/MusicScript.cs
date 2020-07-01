using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Code
{
    public class MusicScript : MonoBehaviour
    {
        private const float MUSIC_OFF = -80f;
        private const float MUSIC_ON = -20f;
        
        
        [SerializeField] private Sprite musicOnSprite = default;
        [SerializeField] private Sprite musicOffSprite = default;
        [SerializeField] AudioMixer am = default;
        [SerializeField] private Button button = default;

        private static bool isMusicOn = true;

        void Start()
        {
            if (isMusicOn)
            {
                button.image.sprite = musicOnSprite;
            }
            else
            {
                button.image.sprite = musicOffSprite;
            }
        }
        public void OnClick()
        {
            float value;
            am.GetFloat("VolumeParam", out value);
            if (value == MUSIC_OFF)
            {
                am.SetFloat("VolumeParam", MUSIC_ON);
                button.image.sprite = musicOnSprite;
                PlayerPrefs.SetFloat(StringConsts.VOLUME, MUSIC_ON);
                isMusicOn = true;
                PlayerPrefs.Save();
            }
            else
            {
                am.SetFloat("VolumeParam", MUSIC_OFF);
                button.image.sprite = musicOffSprite;
                PlayerPrefs.SetFloat(StringConsts.VOLUME, MUSIC_OFF);
                isMusicOn = false;
                PlayerPrefs.Save();
            }
        }
    }
}
