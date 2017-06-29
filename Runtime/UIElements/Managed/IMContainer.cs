// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

namespace UnityEngine.Experimental.UIElements
{
    class IMContainer : VisualContainer, IOnGUIHandler
    {
        public Vector2 translation
        {
            get { return new Vector2(transform.m03, transform.m13); }
            set
            {
                m_Transform.m03 = value.x;
                m_Transform.m13 = value.y;
                Dirty(ChangeType.Repaint);
            }
        }

        public int id { get; set; }

        public bool isTrashed { get; set; }

        private GUIStyle m_GUIStyle;
        // IMContainers have their GUIStyle set directly, and don't use UIElements Style Sheet at the moment
        internal GUIStyle guiStyle
        {
            get { return m_GUIStyle; }
            set
            {
                m_GUIStyle = value;
            }
        }

        public IMContainer()
        {
            guiStyle = GUIStyle.none;
            clipChildren = true; // unlike IMGUI, the IMContainer clips children by default
        }

        public virtual void OnTrash()
        {
        }

        public virtual void OnReuse()
        {
            guiStyle = GUIStyle.none;
            translation = Vector2.zero;
            layout = new Rect(0, 0, 0, 0);
        }

        public virtual bool OnGUI(Event evt)
        {
            return false;
        }

        public virtual void GenerateControlID()
        {
            id = IMElement.NonInteractiveControlID;
        }
    }
}