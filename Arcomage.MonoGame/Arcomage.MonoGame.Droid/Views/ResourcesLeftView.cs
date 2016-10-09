using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class ResourcesLeftView : View<ResourcesViewModel>
    {
        public ResourcesLeftView(ContentManager contentManager)
        {
            var resourcesLeftImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 170, SizeY = 377, SourceX = 170, SourceY = 377,
                Texture = contentManager.Load<Texture2D>("ResourcesLeftImage")
            };
            
            Items.Add(resourcesLeftImageView);
        }
    }
}
