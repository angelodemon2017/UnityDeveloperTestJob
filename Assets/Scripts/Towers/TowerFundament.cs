using UnityEngine;

namespace Towers
{
    public class TowerFundament : MonoBehaviour
    {
        [SerializeField] private Transform PointWeapon;
        public Transform GetPointWeapon => PointWeapon;
    }
}