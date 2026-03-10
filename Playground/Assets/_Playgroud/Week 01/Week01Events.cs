using UnityEngine;
using UnityEngine.Events;

namespace Week01
{
    public class Week01Events : MonoBehaviour
    {
        [SerializeField]
        UnityEvent manageCubes;

        private void Awake()
        {
            manageCubes.AddListener(SomethingToDo);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                manageCubes.Invoke();
            }
        }
        private void SomethingToDo()
        {
            print("Something to do");
        }
    }
}
