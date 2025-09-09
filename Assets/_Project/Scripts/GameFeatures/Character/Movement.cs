using UnityEngine;

namespace _Project.GameFeatures.Character
{
    public class Movement
    {
        private readonly Transform _moveObject;

        public Movement(Transform moveObject) => _moveObject = moveObject; 

        public void Move(Vector3 input, int speed) => 
            _moveObject.position += input * (speed * Time.deltaTime);
    }
}