namespace UnityEngine
{
    public static class GizmosExtensions
    {
        /// <summary>
        /// Нарисовать окружность
        /// </summary>
        /// <param name="center">центр окружности</param>
        /// <param name="radius">радиус окружности</param>
        public static void DrawCircle(Vector3 center, float radius)
        {
            float theta = 0;
            var x = radius * Mathf.Cos(theta);
            var y = radius * Mathf.Sin(theta);
            Vector3 pos = center + new Vector3(x, y, 0);
            Vector3 newPos = pos;
            Vector3 lastPos = pos;
            for(theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f) {
                x = radius * Mathf.Cos(theta);
                y = radius * Mathf.Sin(theta);
                newPos = center + new Vector3(x, y, 0);
                Gizmos.DrawLine(pos, newPos);
                pos = newPos;
            }
            Gizmos.DrawLine(pos, lastPos);
        }

        /// <summary>
        /// Нарисовать эллипс
        /// </summary>
        /// <param name="center">центр эллипса</param>
        /// <param name="size">радиусы эллипса</param>
        public static void DrawEllipse(Vector3 center, Vector2 size)
        {
            float theta = 0;
            var x = size.x * Mathf.Cos(theta);
            var y = size.y * Mathf.Sin(theta);
            Vector3 pos = center + new Vector3(x, y, 0);
            Vector3 newPos = pos;
            Vector3 lastPos = pos;
            for(theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f) {
                x = size.x * Mathf.Cos(theta);
                y = size.y * Mathf.Sin(theta);
                newPos = center + new Vector3(x, y, 0);
                Gizmos.DrawLine(pos, newPos);
                pos = newPos;
            }
            Gizmos.DrawLine(pos, lastPos);
        }

        /// <summary>
        /// Нарисовать прямоугольник
        /// </summary>
        /// <param name="center">центр прямоугольника</param>
        /// <param name="size">размер прямоугольника</param>
        public static void DrawRectangle(Vector3 center, Vector2 size)
        {
            Gizmos.DrawLine(new Vector2(-size.x / 2, size.y / 2), new Vector2(size.x / 2, size.y / 2));
            Gizmos.DrawLine(new Vector2(size.x / 2, size.y / 2), new Vector2(size.x / 2, -size.y / 2));
            Gizmos.DrawLine(new Vector2(size.x / 2, -size.y / 2), new Vector2(-size.x / 2, -size.y / 2));
            Gizmos.DrawLine(new Vector2(-size.x / 2, -size.y / 2), new Vector2(-size.x / 2, size.y / 2));
        }

        /// <summary>
        /// Нарисовать квадрат
        /// </summary>
        /// <param name="center">центр квадрата</param>
        /// <param name="size">размер квадрата</param>
        public static void DrawQuad(Vector3 center, float size)
        {
            Gizmos.DrawLine(new Vector2(-size / 2, size / 2), new Vector2(size / 2, size / 2));
            Gizmos.DrawLine(new Vector2(size / 2, size / 2), new Vector2(size / 2, -size / 2));
            Gizmos.DrawLine(new Vector2(size / 2, -size / 2), new Vector2(-size / 2, -size / 2));
            Gizmos.DrawLine(new Vector2(-size / 2, -size / 2), new Vector2(-size / 2, size / 2));
        }
    }
}
