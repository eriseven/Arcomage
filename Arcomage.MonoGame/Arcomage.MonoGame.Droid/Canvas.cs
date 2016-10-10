using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid
{
    public class Canvas
    {
        private readonly SpriteBatch spriteBatch;

        private readonly Vector2 spritePosition;

        private readonly Vector2 spriteScale;

        public Canvas(SpriteBatch spriteBatch, Vector2 spritePosition, Vector2 spriteScale)
        {
            this.spriteBatch = spriteBatch;
            this.spritePosition = spritePosition;
            this.spriteScale = spriteScale;
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(texture, spritePosition + position * spriteScale, sourceRectangle, color, rotation, origin, scale * spriteScale, effects, layerDepth);
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.DrawString(spriteFont, text, spritePosition + position * spriteScale, color, rotation, origin, scale * spriteScale, effects, layerDepth);
        }

        public Canvas CreateNestedCanvas(Vector2 position, Vector2 scale)
        {
            return new Canvas(spriteBatch, spritePosition + position * spriteScale, scale * spriteScale);
        }
    }
}
