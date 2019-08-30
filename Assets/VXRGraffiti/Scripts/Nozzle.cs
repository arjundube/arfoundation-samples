using UnityEngine;

namespace VXR.Graffiti
{
    /// <summary>
    /// Provides access to the cursor <see cref="MeshRenderer"/> and the spray <see cref="TrailRenderer"/>
    /// as well as manages the internal state of the latter in response to touch events.
    /// </summary>
    public class Nozzle : MonoBehaviour
    {
        #region Editor Variables

        [SerializeField]
        [Tooltip("The renderer for the cursor")]
        MeshRenderer m_cursorRenderer;

        [SerializeField]
        [Tooltip("The renderer for the spray")]
        TrailRenderer m_trailRenderer;

        #endregion

        #region Public Properties

        /// <summary>
        /// The cursor renderer
        /// </summary>
        public MeshRenderer cursor
        {
            get { return m_cursorRenderer; }
        }

        /// <summary>
        /// The trail renderer
        /// </summary>
        public TrailRenderer spray
        {
            get { return m_trailRenderer; }
        }

        #endregion

        #region Unity Methods

        void Update()
        {
            if (Input.touchCount == 0)
            {
                // No fingers on screen, if the current trail is emitting, detach it and create a new one
                if (m_trailRenderer.emitting)
                {
                    CancelInvoke();

                    m_trailRenderer.emitting = false;

                    GameObject newTrail = Instantiate(m_trailRenderer.gameObject);
                    newTrail.transform.parent = transform;
                    newTrail.transform.localPosition = Vector3.zero;
                    newTrail.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);

                    m_trailRenderer.transform.parent = null;
                    m_trailRenderer.gameObject.tag = NozzleManager.INK_TAG;
                    m_trailRenderer.sortingLayerName = NozzleManager.BACKGROUND_LAYER;
                    m_trailRenderer = newTrail.GetComponent<TrailRenderer>();
                }
            }
            else
            {
                // A touch has been detected, start emitting after a brief delay to prevent the trail from jumping
                if (!IsInvoking())
                {
                    Invoke("StartEmitting", 0.1f);
                }
            }
        }

        #endregion

        #region Private Methods

        private void StartEmitting()
        {
            m_trailRenderer.emitting = true;
        }

        #endregion
    }
}
