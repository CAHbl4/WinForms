﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Abstract;

namespace Presentation.Presentors
{
   public class MainPresenter:IPresenter
    {
        readonly IMainView view;
        readonly IMainService service;

        public MainPresenter(IMainView view, IMainService service)
        {
            this.view = view;
            this.service = service;
            view.Open += ShowStud;
        }

        public void ShowStud()
        {
            view.Surnames = service.GetSurnames().ToList<string>();
            view.Names = service.GetNames().ToList<string>();
            view.Heights = service.GetHeidhts().ToList<double>();
            view.Balls = service.GetBalls().ToList<int>();
            view.ShowAll();
        }

        public void Run()
        {
            view.Show();
        }
    }
}
