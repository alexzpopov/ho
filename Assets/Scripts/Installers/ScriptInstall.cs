using UnityEngine;
using Zenject;
namespace Grav
{
    [CreateAssetMenu(fileName = "ScriptInstall", menuName = "Installers/ScriptInstall")]
    public class ScriptInstall : ScriptableObjectInstaller<ScriptInstall>
    {
        [SerializeField]
        private GameSettings _config;
        public override void InstallBindings()
        {

            Container.BindInstance(_config);
        }
    }
}