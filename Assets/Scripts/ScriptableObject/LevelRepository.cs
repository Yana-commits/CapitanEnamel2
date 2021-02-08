using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Level
{
    [Serializable]
    [CreateAssetMenu(menuName = "Level repository")]
    public class LevelRepository : ScriptableObject
    {
        public List<Level> LevelList = new List<Level>();
    }

    [Serializable]
    public class Level
    {
        public Color background;
        public Sprite sceneImage;
        public FallinEnemy fallinEnemy;
       
    }

    [Serializable]
    public class FallinEnemy
    {
        public Sprite sprite;
        public Animator animator;
        public float speed;
        public int damage;
    }
}
