using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Infrаstructure
{
    public class CoroutineStarter : MonoBehaviour
    {
        public void StartSpecificCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public void StopSpecificCoroutine(IEnumerator coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}