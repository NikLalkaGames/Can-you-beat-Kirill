using System;
using UnityEngine;

namespace UI
{
    public class PanelControl : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Start()
        {
            if (animator is null) 
                Debug.LogError("Need to attach animator to PanelControl script");
        }

        public void ShowPanel()
        {
            var clicked = animator.GetBool("Clicked");
            
            animator.SetBool("Clicked", !clicked);
        }
    }
}
