using _Project.GameFeatures.Input;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _speed;
        
        private Movement _movement;
        private InputController _inputController;
        
        [Inject]
        private void Construct(Movement movement, InputController inputController)
        {
            _movement = movement;
            _inputController = inputController;
        }

        private void Update()
        {
            _movement.Move(_inputController.InputVector, _speed);
        }
    }
}