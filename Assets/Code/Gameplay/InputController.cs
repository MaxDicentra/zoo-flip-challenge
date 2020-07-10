using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

namespace Assets.Code.Gameplay
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] GameObject rulesPanel = default;
        private Stopwatch touchLength = new Stopwatch();
        private bool isOncePressed = false;
        private Random rand;

        // Start is called before the first frame update
        void Start()
        {
            rulesPanel.SetActive(false);
            rand = new Random();   
        }

        // Update is called once per frame
        void Update()
        {
            if (!IsPointerOverUIObject())
            {
                if (Input.GetMouseButtonDown(0) )
                {
                    touchLength.Start();
                    PlayerInstance.getInstance().Animator1.SetBool("jump", true);
                    if (!isOncePressed) // hide buttons
                    {
                        isOncePressed = true;
                        ButtonsInstances.Settings.Hide();
                        ButtonsInstances.MoreCharacters.Hide();
                        rulesPanel.SetActive(true);
                    }
                }
            
                if (Input.GetMouseButtonUp(0))
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
        
        //метод для проверки нахождения курсора над UI-элеметами
        bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}
