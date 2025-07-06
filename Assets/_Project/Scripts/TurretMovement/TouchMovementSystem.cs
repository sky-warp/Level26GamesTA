using UnityEngine;

namespace _Project.Scripts.TurretMovement
{
    public class TouchMovementSystem : IInputable
    {
        public float GetAxisVertical()
        {
            float yTouch = 0;

            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                yTouch = touch.deltaPosition.y;
            }

            return yTouch;
        }

        public float GetAxisHorizontal()
        {
            float xTouch = 0;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                xTouch = touch.deltaPosition.x;
            }

            return xTouch;
        }
    }
}