using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

namespace Arcadia.Player2
{
    [RequireComponent(typeof(Player))]
    public class PlayerController : MonoBehaviour
    {
        protected Player _player;
        
        private Vector3 _direction{get;set;}

        private void Start()
        {
            _player = GetComponent<Player>();
        }
        
    }
}