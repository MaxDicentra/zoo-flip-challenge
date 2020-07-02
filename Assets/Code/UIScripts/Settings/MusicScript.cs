using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Code
{
    public class MusicScript : MonoBehaviour
    {
        [SerializeField] private Sprite musicOnSprite = default;
        [SerializeField] private Sprite musicOffSprite = default;
        [SerializeField] AudioMixer am = default;
        [SerializeField] private Button button = default;


        void Start()
        {
            if (PlayerPrefs.HasKey(StringConsts.VOLUME))
            {
                if (PlayerPrefs.GetFloat(StringConsts.VOLUME) == StringConsts.MUSIC_ON)
                {
                    button.image.sprite = musicOnSprite;
                }
                else
                {
                    button.image.sprite = musicOffSprite;
                    am.SetFloat("VolumeParam", StringConsts.MUSIC_OFF);
                }
            }
            else
            {
                PlayerPrefs.SetFloat(StringConsts.VOLUME, StringConsts.MUSIC_ON);
                PlayerPrefs.Save();
                button.image.sprite = musicOnSprite;
            }
        }
        public void OnClick()
        {
            float value;
            am.GetFloat("VolumeParam", out value);
            if (value == StringConsts.MUSIC_OFF)
            {
                am.SetFloat("VolumeParam", StringConsts.MUSIC_ON);
                button.image.sprite = musicOnSprite;
                PlayerPrefs.SetFloat(StringConsts.VOLUME, StringConsts.MUSIC_ON);
                PlayerPrefs.Save();
            }
            else
            {
                am.SetFloat("VolumeParam", StringConsts.MUSIC_OFF);
                button.image.sprite = musicOffSprite;
                PlayerPrefs.SetFloat(StringConsts.VOLUME, StringConsts.MUSIC_OFF);
                PlayerPrefs.Save();
            }
        }
    }
}
 