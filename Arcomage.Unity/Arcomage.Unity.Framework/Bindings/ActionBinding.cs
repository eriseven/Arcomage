﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Framework.Bindings
{
    public sealed class ActionBinding : Binding
    {
        private bool init;

        private readonly Action action;

        public ActionBinding(Action action)
        {
            this.action = action;
        }

        public override void Update()
        {
            action.Invoke();

            if (!init)
            {
                init = true;

                Init?.Invoke();

                return;
            }

            Changed?.Invoke();
        }
        
        public event Action Changed;
        
        public event Action Init;
    }
}
