using UnityEngine;

namespace VXR.Graffiti
{
    /// <summary>
    /// Publishes event handlers for the various buttons in the UI and changes the state of the
    /// currently visible <see cref="Nozzle"/> if there is one active in the scene.
    /// </summary>
    [RequireComponent(typeof(PlaceOnPlane))]
    public class NozzleManager : MonoBehaviour
    {
        #region Constants

        public const string INK_TAG = "Ink";
        public const string BACKGROUND_LAYER = "Background";

        private const int MAX_SIZE_MULTIPLIER = 3;
        private const float SPRAY_WIDTH_BASE = 0.04f;
        private static readonly Vector3 CURSOR_SCALE_BASE = Vector3.one * 0.1f;
        private static readonly Color[] COLORS = { Color.white, Color.gray, Color.black, Color.red, Color.magenta, Color.blue, Color.cyan, Color.green, Color.yellow };

        #endregion

        #region Private Variables

        private PlaceOnPlane m_placeOnPlane = null;
        private Nozzle m_nozzle;
        private int m_colorIndex = 0;
        private int m_sizeMultiplier = 1;

        #endregion

        #region Unity Methods

        void Awake()
        {
            m_placeOnPlane = GetComponent<PlaceOnPlane>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The handler to invoke when the Color button is clicked.
        /// 
        /// This changes the color of the main material on the cursor <see cref="MeshRenderer"/>
        /// and the startColor and endColor of the <see cref="TrailRenderer"/> by cycling through
        /// the colors in <see cref="COLORS"/>.
        /// </summary>
        public void ChangeColor()
        {
            if (!TryGetNozzle(out Nozzle nozzle))
            {
                return;
            }

            m_colorIndex = (m_colorIndex + 1) % COLORS.Length;
            nozzle.cursor.material.color = COLORS[m_colorIndex];
            nozzle.spray.startColor = nozzle.spray.endColor = COLORS[m_colorIndex];
        }

        /// <summary>
        /// The handler to invoke when the Size button is clicked.
        /// 
        /// This sets the localScale on the cursor <see cref="Transform"/> to <see cref="CURSOR_SCALE_BASE"/>
        /// and the widthMultiplier of the <see cref="TrailRenderer"/> to <see cref="SPRAY_WIDTH_BASE"/>
        /// multiplied by 1, 2 or 3.
        /// </summary>
        public void ChangeSize()
        {
            if (!TryGetNozzle(out Nozzle nozzle))
            {
                return;
            }

            m_sizeMultiplier = m_sizeMultiplier != MAX_SIZE_MULTIPLIER ? m_sizeMultiplier + 1 : 1;
            nozzle.cursor.transform.localScale = CURSOR_SCALE_BASE * m_sizeMultiplier;
            nozzle.spray.widthMultiplier = SPRAY_WIDTH_BASE * m_sizeMultiplier;
        }

        /// <summary>
        /// The handler to invoke when the Clear button is clicked.
        /// 
        /// This destroys all the detached spray objects identified by the tag <see cref="INK_TAG"/>
        /// </summary>
        public void Clear()
        {
            if (!TryGetNozzle(out Nozzle nozzle))
            {
                return;
            }

            GameObject[] ink = GameObject.FindGameObjectsWithTag(INK_TAG);
            foreach (GameObject i in ink)
            {
                Destroy(i);
            }
        }

        #endregion

        #region Private Methods

        private bool TryGetNozzle(out Nozzle nozzle)
        {
            if (m_nozzle != null)
            {
                nozzle = m_nozzle;
                return true;
            }

            if (m_placeOnPlane.spawnedObject != null)
            {
                nozzle = m_placeOnPlane.spawnedObject.GetComponent<Nozzle>();
                m_nozzle = nozzle;
                return true;
            }

            nozzle = null;
            return false;
        }

        #endregion
    }
}
