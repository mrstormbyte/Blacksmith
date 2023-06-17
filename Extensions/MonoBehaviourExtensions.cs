using System;

namespace UnityEngine
{
    static class MonoBehaviourExtensions
    {
        //@Roman Sakutin
        /// <summary>
        /// Получить компонент заданного типа и вызвать его метод
        /// </summary>
        /// <param name="monoBehaviour"></param>
        /// <param name="handler">вызываемый метод</param>
        /// <typeparam name="T">тип компонента</typeparam>
        public static void HandleComponent<T>(this MonoBehaviour monoBehaviour, Action<T> handler)
        {
            var component = monoBehaviour.GetComponent<T>();
            if(component != null)
                handler?.Invoke(component);
        }

        /// <summary>
        /// Получить все компоненты заданного типа и вызвать их методы
        /// </summary>
        /// <param name="monoBehaviour"></param>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        public static void HandleComponents<T>(this MonoBehaviour monoBehaviour, Action<T> handler)
        {
            T[] components = monoBehaviour.GetComponents<T>();

            if(components.Length > 0) {
                foreach(T component in components) {
                    handler?.Invoke(component);
                }
            }
        }
    }
}