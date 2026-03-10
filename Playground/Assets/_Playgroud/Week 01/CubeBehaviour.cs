using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Week01
{
    public class CubeBehaviour : MonoBehaviour
    {

        public GameObject cube1;

        [SerializeField]
        private GameObject cube2;

        private GameObject cube3;

        private IEnumerator myICube;

        private void Awake()
        {
            myICube = MoveCube();
        }

        void Start()
        {
            cube3 = gameObject;

            print("This is the Start");
        }

        void Update()
        {
            //Vector3 cubePosition = cube3.transform.position;
            //cubePosition.y += 1f * Time.deltaTime;
            //cube3.transform.position = cubePosition;

            //print("This is the Start");

            /*if(Input.GetKeyDown(KeyCode.Space))
            {
                print("Key is down");
                StartCoroutine(MoveCube());
            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                print("Key is up");
                StopCoroutine();
            }*/
        }

        IEnumerator MoveCube()
        {
            Vector3 cubePosition = cube3.transform.position;
            while (true)
            {
                cubePosition.y += 1f * Time.deltaTime;
                cube3.transform.position = cubePosition;
                yield return null;
                //yield return new WaitforSeconds(.5f);
            }
        }

        void OnJump(InputValue inputValue)
        {
            if (inputValue.isPressed)
            {
                print("I'm moving the Cube");
                StartCoroutine(myICube);
            }
            else
            {
                print("I'm not moving the Cube");
                StopCoroutine(myICube);
            }
        }
        public void SomethingToDoFromCube()
        {
            print("I'm moving the cube from Something To Do");
            StartCoroutine(myICube);

        }
    }
}
