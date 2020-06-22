using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code
{
    public class JumpButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Stopwatch touchLength = new Stopwatch();
        private bool isOncePressed = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            touchLength.Start();

            if (!isOncePressed) // hide buttons
            {
                isOncePressed = true;
                ButtonsInstances.Ranking.Hide();
                ButtonsInstances.VkButton.Hide();
                ButtonsInstances.Settings.Hide();
                ButtonsInstances.MoreCharacters.Hide();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            touchLength.Stop();
            PlayerInstance.getInstance().Jump(touchLength.ElapsedMilliseconds);
            touchLength.Reset();
        }
        
    }
}
