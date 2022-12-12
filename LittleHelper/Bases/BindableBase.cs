using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Bases
{
	public class BindableBase : INotifyPropertyChanged
	{
		//a method to use whenever you implement changgable property
		protected virtual void SetProperty<T>(ref T member, T val,
			[CallerMemberName] string propertyName = null)
		{
			if (object.Equals(member, val)) return;
			member = val;
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		//whenever you do changes to one property that could influence another
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}
