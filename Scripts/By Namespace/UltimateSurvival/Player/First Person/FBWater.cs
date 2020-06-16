using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UltimateSurvival.InputSystem;

namespace UltimateSurvival.GUISystem
{


    public class FBWater : FPObject
    {
        private InputManager m_Input;

        [Header("Raycast Data")]

        [SerializeField]
        private Camera m_WorldCamera;

        [SerializeField]
        private LayerMask m_LayerMask;

        [Header("FP Manager")]

        [SerializeField]
        private FPManager m_FPManager;

        [Header("Audio")]

        [SerializeField]
        private AudioSource m_AudioSource;

        [SerializeField]
        private SoundPlayer m_ActackAudio;

        private SavableItem m_EquippedObject;
        private bool m_canUse = false;
        private float m_RefillAmount = 0f;
        private float m_RefillMax = 0f;

        protected virtual void Start()
        {
            if(!m_FPManager)
            {
                m_FPManager = transform.GetComponentInParent<FPManager>();
            }

            if (GameController.InputManager)
                m_Input = GameController.InputManager;
            else
                enabled = false;

            m_EquippedObject = m_FPManager.m_EquippedObject.CorrespondingItem;


            m_canUse = m_EquippedObject.HasProperty("Can Consume") &&
                m_EquippedObject.HasProperty("Container Capacity") &&
                m_EquippedObject.HasProperty("Container Amount") &&
                m_EquippedObject.HasProperty("Consume Amount");

            if (m_canUse)
            {
                m_RefillAmount = m_EquippedObject.GetPropertyValue("Consume Amount").Float.Current;
                m_RefillMax = m_EquippedObject.GetPropertyValue("Container Capacity").Float.Current;

            }
        }

        private void Update()
        {
            if (m_Input.GetButtonDown("Reload"))
            {
                var ray = m_WorldCamera.ViewportPointToRay(Vector2.one * 0.5f);

                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, 2, m_LayerMask))
                {
                    var raycastData = new RaycastData(hitInfo);
                    if (!raycastData)
                        return;
                    if(m_canUse)
                    {
                        //var m_RefillAmount = m_EquippedObject.GetPropertyValue("Consume Amount").Float.Current;
                        var CurrentAmount = m_EquippedObject.GetPropertyValue("Container Amount").Float;

                        if(
                            CurrentAmount.Current >= m_RefillMax
                            )
                        {
                            MessageDisplayer.Instance.PushMessage(
                                string.Format("<color=red>{0}</color> is already full", m_EquippedObject.Name)
                            );
                            return;
                        }

                        CurrentAmount.Current += m_RefillAmount;
                        CurrentAmount.Current = Mathf.Clamp((CurrentAmount.Current), 0.0f, m_RefillMax);

                        m_EquippedObject.GetPropertyValue("Container Amount").SetValue(ItemProperty.Type.Float, CurrentAmount);

                        m_ActackAudio.Play(ItemSelectionMethod.Randomly, m_AudioSource, 0.6f);

                        if(
                            m_EquippedObject.GetPropertyValue("Container Amount").Float.Current >= m_RefillMax
                            )
                        {
                            MessageDisplayer.Instance.PushMessage(
                                string.Format("<color=blue>{0}</color> is full", m_EquippedObject.Name)
                                );
                            return;
                        }
                        else
                        {
                            MessageDisplayer.Instance.PushMessage(
                                string.Format("<color=yellow>{0}</color> is partially refilled", m_EquippedObject.Name)
                                );
                            return;
                        }
                        
                    }
                }
            }
        }
    }
}