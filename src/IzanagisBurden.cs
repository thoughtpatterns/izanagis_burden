using System.Security;
using System.Security.Permissions;
using BepInEx;
using UnityEngine.AddressableAssets;
using UnityEngine;
using System.Reflection;
using RoR2.Skills;

#pragma warning disable CS0618
[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618

namespace IzanagisBurden
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class IzanagisBurden : BaseUnityPlugin
    {
        public const string PluginGUID = "com." + PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "goatmedia";
        public const string PluginName = "IzanagisBurden";
        public const string PluginVersion = "1.0.0";
        public static AssetBundle assetBundle;

        public static IzanagisBurden instance { get; private set; }

        public void Awake()
        {
            Log.Init(this.Logger);
            InsertIcons();
        }

        private void InsertIcons()
        {
            assetBundle = AssetBundle.LoadFromFile(Assembly.GetExecutingAssembly().Location.Replace("IzanagisBurden.dll", "izanagis_burden"));

            var cryocharge = Addressables.LoadAssetAsync<SkillDef>("RoR2/DLC1/Railgunner/RailgunnerBodyChargeSnipeCryo.asset").WaitForCompletion();
            cryocharge.icon = assetBundle.LoadAsset<Sprite>("cryocharge.png");

            var supercharge = Addressables.LoadAssetAsync<SkillDef>("RoR2/DLC1/Railgunner/RailgunnerBodyChargeSnipeSuper.asset").WaitForCompletion();
            supercharge.icon = assetBundle.LoadAsset<Sprite>("supercharge.png");
        }
    }
} 
