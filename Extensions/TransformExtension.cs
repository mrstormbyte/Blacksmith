namespace UnityEngine
{
    static class TransformExtension
    {
        /// <summary>
        /// Повернуть трансформацию объект по оси Z, используя eulerAngles
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newAngle">новый угол</param>
        public static void SetAngleZ(this Transform transform, float newAngle)
        {
            Vector3 newRotation = transform.eulerAngles;
            newRotation.z = newAngle;
            transform.eulerAngles = newRotation;
        }


        #region position
        /// <summary>
        /// Установить новую координату Х
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newX">новая координата X</param>
        public static void SetPositionX(this Transform transform, float newX)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newX;
            transform.position = newPosition;
        }
        
        /// <summary>
        /// Установить новую координату Y
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newY">новая координата Y</param>
        public static void SetPositionY(this Transform transform, float newY)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = newY;
            transform.position = newPosition;
        }
        
        /// <summary>
        /// Установить новую координату Z
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newZ">новая координата Z</param>
        public static void SetPositionZ(this Transform transform, float newZ)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = newZ;
            transform.position = newPosition;
        }
        #endregion

        
        #region localScale
        /// <summary>
        /// Установить новый скейл по Х
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newLocalScaleX">новый скейл по Х</param>
        public static void SetlocalScaleX(this Transform transform, float newLocalScaleX)
        {
            Vector3 newLocalScale = transform.localScale;
            newLocalScale.x = newLocalScaleX;
            transform.localScale = newLocalScale;
        }
        
        /// <summary>
        /// Установить новый скейл по Y
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newLocalScaleY">новый скейл по Y</param>
        public static void SetlocalScaleY(this Transform transform, float newLocalScaleY)
        {
            Vector3 newLocalScale = transform.localScale;
            newLocalScale.y = newLocalScaleY;
            transform.localScale = newLocalScale;
        }
        
        /// <summary>
        /// Установить новый скейл по Z
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newLocalScaleZ">новый скейл по Z</param>
        public static void SetlocalScaleZ(this Transform transform, float newLocalScaleZ)
        {
            Vector3 newLocalScale = transform.localScale;
            newLocalScale.z = newLocalScaleZ;
            transform.localScale = newLocalScale;
        }
        #endregion
    }
}