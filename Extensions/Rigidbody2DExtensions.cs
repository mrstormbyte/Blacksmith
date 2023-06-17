namespace UnityEngine
{
    public static class Rigidbody2DExtensions
    {
        #region AddForce
        /// <summary>
        /// Добавить силу от взрыва
        /// </summary>
        /// <param name="rb">тело</param>
        /// <param name="explosionForce">сила взрыва</param>
        /// <param name="explosionPosition">позиция взрыва</param>
        /// <param name="explosionRadius">радиус взрыва</param>
        /// <param name="upwardsModifier"></param>
        /// <param name="mode"></param>
        public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
        {
            var explosionDir = rb.position - explosionPosition;
            var explosionDistance = explosionDir.magnitude;

            // Normalize without computing magnitude again
            if(upwardsModifier == 0)
                explosionDir /= explosionDistance;
            else {
                explosionDir.y += upwardsModifier;
                explosionDir.Normalize();
            }

            rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
        }

        /// <summary>
        /// Сбросить скорость тела и добавить силу
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="force">сила</param>
        /// <param name="forceMode2D"></param>
        public static void AddPureForce(this Rigidbody2D rb, Vector2 force, ForceMode2D forceMode2D = ForceMode2D.Force)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(force, forceMode2D);
        }
        /// <summary>
        /// Добавить силу по X, не трогая силу по Y
        /// </summary>
        /// <param name="rb">тело</param>
        /// <param name="forceX">сила по Х</param>
        /// <param name="forceMode2D"></param>
        public static void AddForceX(this Rigidbody2D rb, float forceX, ForceMode2D forceMode2D = ForceMode2D.Force)
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.x = forceX;
            rb.AddForce(newVelocity, forceMode2D);
        }
        /// <summary>
        /// Добавить чистую силу по X, не трогая силу по Y
        /// </summary>
        /// <param name="rb">тело</param>
        /// <param name="forceX">сила по X</param>
        /// <param name="forceMode2D"></param>
        public static void AddPureForceX(this Rigidbody2D rb, float forceX, ForceMode2D forceMode2D = ForceMode2D.Force)
        {
            rb.SetVelocityX(0);
            rb.AddForceX(forceX);
        }
        /// <summary>
        /// Добавить силу по Y, не трогая силу по X
        /// </summary>
        /// <param name="rb">тело</param>
        /// <param name="forceY">сила по Y</param>
        /// <param name="forceMode2D"></param>
        public static void AddForceY(this Rigidbody2D rb, float forceY, ForceMode2D forceMode2D = ForceMode2D.Force)
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = forceY;
            rb.AddForce(newVelocity, forceMode2D);
        }
        /// <summary>
        /// Добавить чистую силу по Y, не трогая силу по X
        /// </summary>
        /// <param name="rb">тело</param>
        /// <param name="forceY">сила по Y</param>
        /// <param name="forceMode2D"></param>
        public static void AddPureForceY(this Rigidbody2D rb, float forceY, ForceMode2D forceMode2D = ForceMode2D.Force)
        {
            rb.SetVelocityY(0);
            rb.AddForceY(forceY);
        }
        #endregion
        

        #region position
        /// <summary>
        /// Установить новую координату Х
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="newX">новая координата X</param>
        public static void SetPositionX(this Rigidbody2D rb, float newX)
        {
            Vector3 newPosition = rb.position;
            newPosition.x = newX;
            rb.position = newPosition;
        }
        /// <summary>
        /// Установить новую координату Y
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newY">новая координата Y</param>
        public static void SetPositionY(this Rigidbody2D rb, float newY)
        {
            Vector3 newPosition = rb.position;
            newPosition.y = newY;
            rb.position = newPosition;
        }
        /// <summary>
        /// Установить новую координату Z
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="newZ">новая координата Z</param>
        public static void SetPositionZ(this Rigidbody2D rb, float newZ)
        {
            Vector3 newPosition = rb.position;
            newPosition.z = newZ;
            rb.position = newPosition;
        }
        #endregion

        
        #region velocity
        /// <summary>
        /// Установить скорость по Х
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="newVelocityX">новая скорость по Х</param>
        public static void SetVelocityX(this Rigidbody2D rb, float newVelocityX)
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.x = newVelocityX;
            rb.velocity = newVelocity;
        }
        /// <summary>
        /// Установить скорость по Y
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="newVelocityY">новая скорость по Y</param>
        public static void SetVelocityY(this Rigidbody2D rb, float newVelocityY)
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = newVelocityY;
            rb.velocity = newVelocity;
        }
        #endregion
    }
}