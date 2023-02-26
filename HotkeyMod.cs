using Il2CppSons.Input;
using Il2CppTheForest.Utils;
using MelonLoader;
using UnityEngine;

namespace SoTF_Hotkeys
{
    public class Hotkeys : MelonMod
    {
        private bool bGUI;
        private GUIStyle WatermarkStyle = new GUIStyle();
        private GUIStyle LabelStyle = new GUIStyle();

        private static Dictionary<int, string> ItemDictionary = new Dictionary<int, string>()
        {
            [440] = "Flare",
            [426] = "Printed Flask",
            [443] = "Crafted Bow",
            [365] = "Crossbow",
            [360] = "Compound Bow",
            [394] = "Chainsaw",
            [417] = "Time Bomb",
            [525] = "Putter",
            [367] = "Katana",
            [485] = "Shovel",
            [477] = "Crafted Club",
            [503] = "Torch",
            [474] = "Crafted Spear",
            [459] = "Sling Shot",
            [381] = "Grenade",
            [522] = "Rope Gun",
            [353] = "Stun Gun",
            [396] = "Stun Baton",
            [358] = "Shotgun",
            [355] = "Pistol",
            [356] = "Modern Axe",
            [379] = "Tactical Axe"
        };

        public override void OnInitializeMelon()
        {
            Melon<Hotkeys>.Logger.Msg("Hotkeys loaded, use F10 to show key assigment menu.");
            WatermarkStyle.normal.textColor = Color.yellow;
            LabelStyle.normal.textColor = Color.white;
        }

        public void ToggleMenu()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                bGUI = !bGUI;
                if (bGUI)
                {
                    InputSystem.SetState(0, true);
                    Cursor.visible = true;
                    Cursor.lockState = 0;
                    MelonEvents.OnGUI.Subscribe(new LemonAction(this.Menu), 0, false);
                    return;
                }
                if (!bGUI)
                {
                    InputSystem.SetState(0, false);
                    Cursor.visible = false;
                    Cursor.lockState = (CursorLockMode)1;
                }
            }
        }

        private void Menu()
        {
            if (!bGUI) return;
            GUI.backgroundColor = Color.black;
            GUI.contentColor = Color.white;
            GUILayout.Space(100f);
            GUILayout.BeginVertical("Sons of the Forest", "window", Array.Empty<GUILayoutOption>());
            GUILayout.FlexibleSpace();
            GUILayout.Label("Author: Trey | Version: 1.0.0", new GUILayoutOption[0]);
            GUILayout.Label("———————————————", new GUILayoutOption[0]);
            GUILayout.Space(5f);
            GUILayout.Label("Num 1 Quick Swap", new GUILayoutOption[0]);
            Settings.num1Select = GUILayout.TextField(Settings.num1Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 2 Quick Swap", new GUILayoutOption[0]);
            Settings.num2Select = GUILayout.TextField(Settings.num2Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 3 Quick Swap", new GUILayoutOption[0]);
            Settings.num3Select = GUILayout.TextField(Settings.num3Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 4 Quick Swap", new GUILayoutOption[0]);
            Settings.num4Select = GUILayout.TextField(Settings.num4Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 5 Quick Swap", new GUILayoutOption[0]);
            Settings.num5Select = GUILayout.TextField(Settings.num5Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 6 Quick Swap", new GUILayoutOption[0]);
            Settings.num6Select = GUILayout.TextField(Settings.num6Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 7 Quick Swap", new GUILayoutOption[0]);
            Settings.num7Select = GUILayout.TextField(Settings.num7Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 8 Quick Swap", new GUILayoutOption[0]);
            Settings.num8Select = GUILayout.TextField(Settings.num8Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 9 Quick Swap", new GUILayoutOption[0]);
            Settings.num9Select = GUILayout.TextField(Settings.num9Select);
            GUILayout.Space(15f);
            GUILayout.Label("Num 0 Quick Swap", new GUILayoutOption[0]);
            Settings.num0Select = GUILayout.TextField(Settings.num0Select);

            GUILayout.EndVertical();
        }

        public override void OnUpdate()
        {
            this.ToggleMenu();
            if (Input.GetKeyDown(KeyCode.Alpha1) && Settings.num1Select != "null")
            {
                TryEquip(Settings.num1Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && Settings.num2Select != "null")
            {
                TryEquip(Settings.num2Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && Settings.num3Select != "null")
            {
                TryEquip(Settings.num3Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && Settings.num4Select != "null")
            {
                TryEquip(Settings.num4Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && Settings.num5Select != "null")
            {
                TryEquip(Settings.num5Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6) && Settings.num6Select != "null")
            {
                TryEquip(Settings.num6Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7) && Settings.num7Select != "null")
            {
                TryEquip(Settings.num7Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha8) && Settings.num8Select != "null")
            {
                TryEquip(Settings.num8Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha9) && Settings.num9Select != "null")
            {
                TryEquip(Settings.num9Select);
            }
            if (Input.GetKeyDown(KeyCode.Alpha0) && Settings.num0Select != "null")
            {
                TryEquip(Settings.num0Select);
            }
        }

        public void TryEquip(string itemName)
        {
            LocalPlayer.Inventory.TryEquip(GetIIdByName(itemName), false, false);
        }


        public int GetIIdByName(string name)
        {
            foreach(var entry in ItemDictionary)
            {
                if (entry.Value == name) return entry.Key;
            }
            return -1;
        }

        public string GetINameById(int id)
        {
            foreach (var entry in ItemDictionary)
            {
                if (entry.Key == id) return entry.Value;
            }
            return "null";
        }
    }
}