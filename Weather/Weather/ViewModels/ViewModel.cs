﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Weather.ViewModels
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
