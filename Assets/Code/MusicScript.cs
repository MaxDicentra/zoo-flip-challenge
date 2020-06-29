using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Code
{
    public class MusicScript : MonoBehaviour
    {
        private const float MUSIC_OFF = -80f;
        private const float MUSIC_ON = 0f;
        [SerializeField] private Sprite musicOnSprite = default;
        [SerializeField] private Sprite musicOffSprite = default;
        [SerializeField] AudioMixer am = default;
        [SerializeField] private Button button = default;
        
        
        public void OnClick()
        {
            if (button.image.sprite == musicOnSprite)
            {
                button.image.sprite = musicOffSprite;
            }
            else
            {
                button.image.sprite = musicOnSprite;
            }
            
            // float value;
            // am.GetFloat("VolumeParam", out value);
            // if (value == MUSIC_OFF)
            // {
            //     am.SetFloat("VolumeParam", MUSIC_ON);
            // }
            // else
            // {
            //     am.SetFloat("VolumeParam", MUSIC_OFF);
            // }
        }
    }
}
