using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obi
{
    public class pinhole : ObiParticleAttachment
    {
        public bool testing;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /*private override void UpdateStaticAttachment(float stepTime)
        {

            if (enabled && m_AttachmentType == AttachmentType.Static && m_Actor.isLoaded && isBound)
            {
                var solver = m_Actor.solver;
                var blueprint = m_Actor.sourceBlueprint;

                // Build the attachment matrix:
                Matrix4x4 attachmentMatrix = solver.transform.worldToLocalMatrix * m_Target.localToWorldMatrix;

                // Fix all particles in the group and update their position:
                for (int i = 0; i < m_SolverIndices.Length; ++i)
                {
                    int solverIndex = m_SolverIndices[i];

                    if (solverIndex >= 0 && solverIndex < solver.invMasses.count)
                    {
                        solver.invMasses[solverIndex] = 0;
                        solver.velocities[solverIndex] = Vector3.zero;

                        // Note: skip assignment to startPositions if you want attached particles to be interpolated too.
                        solver.startPositions[solverIndex] = solver.positions[solverIndex] = attachmentMatrix.MultiplyPoint3x4(m_PositionOffsets[i]);
                    }
                }

                if (m_Actor.usesOrientedParticles && m_ConstrainOrientation)
                {
                    Quaternion attachmentRotation = attachmentMatrix.rotation;

                    for (int i = 0; i < m_SolverIndices.Length; ++i)
                    {
                        int solverIndex = m_SolverIndices[i];

                        if (solverIndex >= 0 && solverIndex < solver.invRotationalMasses.count)
                        {
                            solver.invRotationalMasses[solverIndex] = 0;
                            solver.angularVelocities[solverIndex] = Vector3.zero;
                            //solver.angularVelocities[solverIndex] = new Vector3(0, 0, 1);

                            // Note: skip assignment to startPositions if you want attached particles to be interpolated too.
                            solver.startOrientations[solverIndex] = solver.orientations[solverIndex] = attachmentRotation * m_OrientationOffsets[i];
                        }
                    }
                }
            }
        }*/
    }
}


