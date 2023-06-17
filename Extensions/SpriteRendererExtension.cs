namespace UnityEngine
{
    static class SpriteRendererExtension
    {
        /// <summary>
        /// Установить цвет спрайта, не затрагивая его прозрачность
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="newColor">новый цвет</param>
        public static void SetColor(this SpriteRenderer sprite, Color newColor)
        {
            newColor.a = sprite.color.a;
            sprite.color = newColor;
        }

        /// <summary>
        /// Установить прозрачность спрайта
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="newAlpha">новая прозрачность</param>
        public static void SetAlpha(this SpriteRenderer sprite, float newAlpha)
        {
            Color newColor = sprite.color;
            newColor.a = newAlpha;
            sprite.color = newColor;
        }
    }
}