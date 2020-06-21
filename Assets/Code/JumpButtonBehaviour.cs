using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code
{
    public class JumpButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Stopwatch touchLength = new Stopwatch();

        public void OnPointerDown(PointerEventData eventData)
        {
            touchLength.Start();
            // remove buttons etc
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            touchLength.Stop();
            PlayerInstance.getInstance().Jump(touchLength.ElapsedMilliseconds);
            touchLength.Reset();
        }
    }
}
