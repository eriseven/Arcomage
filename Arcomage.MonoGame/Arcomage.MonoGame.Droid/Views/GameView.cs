using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Arcomage.MonoGame.Droid.Views
{
    public class GameView : View<GameViewModel>
    {
        public GameView(ContentManager contentManager, GameViewModel gameViewModel)
            : base(gameViewModel, 1280, 720)
        {
            var gameBorderImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720, SourceX = 1280, SourceY = 720,
                Texture = contentManager.Load<Texture2D>("GameBorderImage")
            };

            var gameBackgroundImageView = new SpriteView
            {
                PositionX = 0, PositionY = 0, SizeX = 1280, SizeY = 720, SourceX = 1280, SourceY = 720,
                Texture = contentManager.Load<Texture2D>("GameBackgroundImage")
            };

            var resourcesLeftView = new ResourcesLeftView(contentManager, gameViewModel.ResourcesLeft)
            {
                PositionX = 2, PositionY = 9, SizeX = 170, SizeY = 377
            };

            var resourcesRightView = new ResourcesRightView(contentManager, gameViewModel.ResourcesRight)
            {
                PositionX = 1109, PositionY = 9, SizeX = 170, SizeY = 377
            };

            var buildingsLeftView = new BuildingsLeftView(contentManager, gameViewModel.BuildingsLeft)
            {
                PositionX = 121, PositionY = 42, SizeX = 300, SizeY = 488
            };

            var buildingsRightView = new BuildingsRightView(contentManager, gameViewModel.BuildingsRight)
            {
                PositionX = 871, PositionY = 42, SizeX = 300, SizeY = 488
            };

            var cardSetView = new CardSetView(contentManager, gameViewModel.CardSet)
            {
                PositionX = 5, PositionY = 384, SizeX = 1270, SizeY = 315
            };
            
            Items.Add(gameBackgroundImageView);
            Items.Add(resourcesLeftView);
            Items.Add(resourcesRightView);
            Items.Add(buildingsLeftView);
            Items.Add(buildingsRightView);
            Items.Add(cardSetView);
            Items.Add(gameBorderImageView);
        }
    }
}
