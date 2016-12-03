﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class HistoryCardScript : View
    {
        [Tooltip("Текст для вывода названия карты")]
        public TextMesh NameText;

        [Tooltip("Текст для вывода описания карты")]
        public TextMesh DescriptionText;

        [Tooltip("Текст для вывода стоимости карты")]
        public TextMesh PriceText;

        [Tooltip("Текст для вывода сброшенности карты")]
        public TextMesh DiscardText;

        [Tooltip("Спрайт фона карты")]
        public SpriteRenderer BackgroundImage;

        [Tooltip("Спрайт изображения карты")]
        public SpriteRenderer ForegroundImage;

        [NonSerialized]
        public int Index;

        public void Initialize(HistoryCard historyCard)
        {
            historyCard.Card.Identifier = historyCard.Card.GetIdentifier();

            Bind(historyCard, c => c.Card.Identifier)
                .OnChangedAndInit(i => ForegroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + i + "Image"))
                .OnChangedAndInit(i => NameText.text = Localization.ResourceManager.GetString("Card" + i + "Name"))
                .OnChangedAndInit(i => DescriptionText.text = Localization.ResourceManager.GetString("Card" + i + "Description"));

            Bind(historyCard, c => c.Card.GetResources())
                .OnChangedAndInit(r => BackgroundImage.sprite = UnityEngine.Resources.Load<Sprite>("Card" + r + "Image"));

            Bind(historyCard, c => c.Card.ResourcePrice)
                .OnChangedAndInit(p => PriceText.text = p.ToString());

            Bind(historyCard, c => c.IsPlayed)
                .OnChangedAndInit(b => DiscardText.gameObject.SetActive(!b))
                .OnChangedAndInit(b => DiscardText.text = Localization.ResourceManager.GetString("CardDiscardText"));
        }
    }
}