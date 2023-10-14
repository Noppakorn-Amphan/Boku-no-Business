using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class VariableStoreTesting : MonoBehaviour
    {
        public int var_int = 0;
        public float var_flt = 0;
        public bool var_bool = false;
        public string var_str = "";
        void Start()
        {
            VariableStore.CreateDatabase("DB_Links");

            VariableStore.CreateVariable("DB_Links.L_int", var_int, () => var_int, value => var_int = value);
            VariableStore.CreateVariable("DB_Links.L_flt", var_flt, () => var_flt, value => var_flt = value);
            VariableStore.CreateVariable("DB_Links.L_bool", var_bool, () => var_bool, value => var_bool = value);
            VariableStore.CreateVariable("DB_Links.L_str", var_str, () => var_str, value => var_str = value);

            VariableStore.CreateDatabase("DB_Numbers");
            VariableStore.CreateDatabase("DB_Booleans");

            VariableStore.CreateVariable("DB_Numbers.num1", 1);
            VariableStore.CreateVariable("DB_Numbers.num2", 5);
            VariableStore.CreateVariable("DB_Booleans.lightIsOn", true);
            VariableStore.CreateVariable("DB_Numbers.float1", 0.75f);
            VariableStore.CreateVariable("str1", "Hello");
            VariableStore.CreateVariable("str2", "World");

            VariableStore.PrintAllDatabases();

            VariableStore.PrintAllVariables();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                VariableStore.PrintAllVariables();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                string variable = "DB_Numbers.num1";
                VariableStore.TryGetValue(variable, out object v);
                VariableStore.TrySetValue(variable, (int)v + 5);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                VariableStore.TryGetValue("DB_Numbers.num1", out object num1);
                VariableStore.TryGetValue("DB_Numbers.num2", out object num2);
                Debug.Log($"num1 + num2 = {(int)num1 + (int)num2}");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (VariableStore.TryGetValue("DB_Booleans.lightIsOn", out object lightIsOn) && lightIsOn is bool)
                    VariableStore.TrySetValue("DB_Booleans.lightIsOn", !(bool)lightIsOn);

            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                VariableStore.TryGetValue("str1", out object str_hello);
                VariableStore.TryGetValue("str2", out object str_world);
                VariableStore.TrySetValue("str1", (string)str_hello + str_world);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                VariableStore.TryGetValue("DB_Links.L_int", out object linked_integer);
                VariableStore.TrySetValue("DB_Links.L_int", (int)linked_integer + 5);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                VariableStore.RemoveVariable("DB_Links.L_int");
                VariableStore.RemoveVariable("DB_Booleans.lightIsOn");
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                VariableStore.RemoveAllVariables();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                VariableStore.TryGetValue("DB_Links.L_flt", out object v);
                VariableStore.TrySetValue("DB_Links.L_flt", (float)v * 1.75f);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                VariableStore.TryGetValue("DB_Links.L_bool", out object v);
                VariableStore.TrySetValue("DB_Links.L_bool", !(bool)v);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                VariableStore.TryGetValue("DB_Links.L_str", out object v);
                VariableStore.TrySetValue("DB_Links.L_str", (string)v + " world");
            }
        }
    }
}