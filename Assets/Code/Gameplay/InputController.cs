using System.Diagnostics;
using UnityEngine;
using Random = System.Random;

namespace Assets.Code.Gameplay
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Camera camera = default;
        [SerializeField] GameObject rulesPanel = default;
        private Stopwatch touchLength = new Stopwatch();
        private bool isOncePressed = false;
        private Random rand;

        private RaycastHit2D hit;
        private Ray2D ray;

        // Start is called before the first frame update
        void Start()
        {
            rulesPanel.SetActive(false);
            rand = new Random();   
        }

        // Update is called once per frame
        void Update()
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != ButtonsInstances.Settings && hit.transform != ButtonsInstances.MoreCharacters)
            {
                if (Input.GetMouseButtonDown(0))
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
    }
}
