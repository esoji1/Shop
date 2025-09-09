using _Project.GameFeatures.MoneySystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Debug
{
    public class SceneDebug : MonoBehaviour
    {
        [Inject] [ShowInInspector, HideInEditorMode]
        private MoneyStorage _moneyStorage;
    }
}