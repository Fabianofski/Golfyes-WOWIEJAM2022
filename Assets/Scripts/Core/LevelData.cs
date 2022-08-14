using UnityEngine;

namespace F4B1.Core
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "new LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public int levelID;
        public int par;
        private int _strokeSession;
        public int StrokeSession
        {
            get { return _strokeSession;}
            set
            {
                _strokeSession = value;
                if (value > StrokeHighScore) 
                    StrokeHighScore = value;
            }
        }
        public int StrokeHighScore { get; private set; }
    }
}