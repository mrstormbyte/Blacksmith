namespace UnityEngine
{
    static class RectTransformExtension
    {
        /// <summary>
        /// Повернуть игровой объект по оси Z, используя eulerAngles
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="newAngle">новый угол</param>
        public static void SetAngleZ(this RectTransform rectTransform, float newAngle)
        {
            Vector3 newRotation = rectTransform.eulerAngles;
            newRotation.z = newAngle;
            rectTransform.eulerAngles = newRotation;
        }


        /// <summary>
        /// Изменить размер X параметра sizeDelta
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="newSizeDeltaX">новый размер X</param>
        public static void SetSizeDeltaX(this RectTransform rectTransform, float newSizeDeltaX)
        {
            Vector2 newSizeDelta = rectTransform.sizeDelta;
            newSizeDelta.x = newSizeDeltaX;
            rectTransform.sizeDelta = newSizeDelta;
        }
        /// <summary>
        /// Изменить размер Y параметра sizeDelta
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="newSizeDeltaY">новый размер Y</param>
        public static void SetSizeDeltaY(this RectTransform rectTransform, float newSizeDeltaY)
        {
            Vector2 newSizeDelta = rectTransform.sizeDelta;
            newSizeDelta.y = newSizeDeltaY;
            rectTransform.sizeDelta = newSizeDelta;
        }
    }
}