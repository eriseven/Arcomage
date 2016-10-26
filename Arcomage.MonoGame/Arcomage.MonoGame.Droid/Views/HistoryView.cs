using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Arcomage.MonoGame.Droid.Views
{
    public class HistoryView : View<HistoryViewModel>
    {
        private readonly ContentManager contentManager;

        private bool isResetCollection;

        public HistoryView(ContentManager contentManager, HistoryViewModel historyViewModel)
            : base(historyViewModel, 300, 300)
        {
            this.contentManager = contentManager;
            historyViewModel.CardCollection.CollectionChanged += CardCollectionOnCollectionChanged;

            if (historyViewModel.CardCollection.Count != 0)
            {
                var cardOffset = new Vector2(10f);
                var cardDelta = new Vector2(150f, 50f);
                var cardSize = new Vector2(130f, 181f);

                Items.AddRange(historyViewModel.CardCollection.Select((vm, i) => InitializeCard(vm, cardOffset, cardDelta, cardSize, i)));
            }
        }

        private void CardCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (isResetCollection)
            {
                Items.Clear();
                isResetCollection = false;
            }

            if (args.Action == NotifyCollectionChangedAction.Reset)
            {
                isResetCollection = true;
            }

            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                var cardOffset = new Vector2(10f);
                var cardDelta = new Vector2(150f, 50f);
                var cardSize = new Vector2(130f, 181f);

                Items.Add(InitializeCard(ViewModel.CardCollection[args.NewStartingIndex], cardOffset, cardDelta, cardSize, args.NewStartingIndex));
            }
        }

        private CardView InitializeCard(CardViewModel cardViewModel, Vector2 cardOffset, Vector2 cardDelta, Vector2 cardSize, int index)
        {
            return new CardView(contentManager, cardViewModel)
            {
                Position = cardOffset + cardDelta * new Point(index % 2, index / 2).ToVector2(),
                Size = cardSize
            };
        }
    }
}