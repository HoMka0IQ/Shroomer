using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
    public class RiverSound : MonoBehaviour
    {
        public CinemachinePathBase m_Path;              // The path to follow
        public Transform Player;                       // The object to track

        float m_Position;                               // The position along the path to set the cart to in path units
        private CinemachinePathBase.PositionUnits m_PositionUnits = CinemachinePathBase.PositionUnits.PathUnits;

        void Update()
        {
            // Find closest point to the player along the path
            SetCartPosition(m_Path.FindClosestPoint(Player.transform.position, 0, -1, 1));
        }

        // Set cart's position to closest point
        void SetCartPosition(float distanceAlongPath)
        {
            m_Position = m_Path.StandardizeUnit(distanceAlongPath, m_PositionUnits);
            transform.position = m_Path.EvaluatePositionAtUnit(m_Position, m_PositionUnits);
            transform.rotation = m_Path.EvaluateOrientationAtUnit(m_Position, m_PositionUnits);
        }
    }
}
