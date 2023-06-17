using System;

namespace UnityEngine
{
    static class Collision2DExtensions
    {
        //@Roman Sakutin
        /// <summary>
        /// Получить компонент заданного типа и вызвать его метод
        /// </summary>
        /// <param name="collision"></param>
        /// <param name="handler">вызываемый метод</param>
        /// <typeparam name="T">тип компонента</typeparam>
        public static void HandleComponent<T>(this Collision2D collision, Action<T> handler)
        {
            var component = collision.gameObject.GetComponent<T>();
            if(component != null)
                handler?.Invoke(component);
        }

        /// <summary>
        /// Получить все компоненты заданного типа и вызвать их методы
        /// </summary>
        /// <param name="collider"></param>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        public static void HandleComponents<T>(this Collision2D collision, Action<T> handler)
        {
            T[] components = collision.gameObject.GetComponents<T>();

            if(components.Length > 0) {
                foreach(T component in components) {
                    handler?.Invoke(component);
                }
            }
        }
    }
}
