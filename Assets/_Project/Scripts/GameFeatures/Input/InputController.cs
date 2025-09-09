using System;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Input
{
    public class InputController : ITickable
    {
        public Vector2 InputVector;

        public event Action OnKeyClickedE;
        
        public void Tick()
        {
            MoveInput();
            ClickedKey();
        }
        
        private void MoveInput()
        {
            float inputHorizontal = UnityEngine.Input.GetAxis("Horizontal");
            float inputVertical = UnityEngine.Input.GetAxis("Vertical");
            
            InputVector = new Vector2(inputHorizontal, inputVertical);
        }

        private void ClickedKey()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                OnKeyClickedE?.Invoke();
            }
        }
    }
}
