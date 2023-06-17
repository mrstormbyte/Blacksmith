using System;

namespace UnityEngine
{
    static class GameObjectExtensions
    {
        /// <summary>
        /// Повернуть игровой объект по оси Z, используя eulerAngles
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="newAngle">новый угол</param>
        public static void SetAngleZ(this GameObject gameObject, float newAngle)
        {
            Vector3 newRotation = gameObject.transform.eulerAngles;
            newRotation.z = newAngle;
            gameObject.transform.eulerAngles = newRotation;
        }

        //@Roman Sakutin
        /// <summary>
        /// Получить компонент заданного типа и вызвать его метод
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="handler">вызываемый метод</param>
        /// <typeparam name="T">тип компонента</typeparam>
        public static void HandleComponent<T>(this GameObject gameObject, Action<T> handler)
        {
            var component = gameObject.GetComponent<T>();
            if(component != null)
                handler?.Invoke(component);
        }

        /// <summary>
        /// Получить все компоненты заданного типа и вызвать их методы
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        public static void HandleComponents<T>(this GameObject gameObject, Action<T> handler)
        {
            T[] components = gameObject.GetComponents<T>();

            if(components.Length > 0) {
                foreach(T component in components) {
                    handler?.Invoke(component);
                }
            }
        }
    }
}