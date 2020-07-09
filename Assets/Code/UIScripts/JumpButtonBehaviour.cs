using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

namespace Assets.Code
{
    public class JumpButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] GameObject rulesPanel = default;
        private Stopwatch touchLength = new Stopwatch();
        private bool isOncePressed = false;
        private Random rand;

        void Start()
        {
            rulesPanel.SetActive(false);
            rand = new Random();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            touchLength.Start();

            if (!isOncePressed) // hide buttons
            {
                isOncePressed = true;
                ButtonsInstances.Settings.Hide();
                ButtonsInstances.MoreCharacters.Hide();
                rulesPanel.SetActive(true);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {           
            if (PlayerInstance.getInstance().IsOnPlatform)
            {
                // choosing next platform position
                if (PlayerInstance.getInstance().transform.position.y >
                    PlatformsController.CurrentPlatform.transform.position.y) 
                {             
                    PlayerInstance.getInstance().transform.SetParent(PlayerInstance.getInstance().MyParent);
                    PlatformsController.CurrentPlatform.NextPos = 
                        PlatformsController.CurrentPlatform.Positions[rand.Next(PlatformsController.CurrentPlatform.Positions.Count)]; 
                    PlatformsController.CurrentPlatform.HasPlayerOn = false;
                    PlatformsController.CurrentPlatform.IsOnJumpPos = false;
                    PlatformsController.CurrentPlatform.Collider.isTrigger = true;
                }
                rulesPanel.SetActive(false);
            }
            touchLength.Stop();
            PlayerInstance.getInstance().Jump(touchLength.ElapsedMilliseconds);
            touchLength.Reset();
            if (PlatformsController.CurrentPlatform != null)
            {
                PlatformsController.CurrentPlatform.Collider.isTrigger = true;
            }
        }
    }
}
