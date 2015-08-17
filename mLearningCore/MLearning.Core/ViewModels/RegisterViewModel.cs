using System;
using MLearning.Core.Services;
using Cirrious.MvvmCross.ViewModels;

namespace MLearning.Core
{
	public class RegisterViewModel: MvxViewModel
	{


		private IMLearningService _mLearningService;


		public RegisterViewModel(IMLearningService mLearningService)
		{
			_mLearningService = mLearningService;
		}

	}
}

