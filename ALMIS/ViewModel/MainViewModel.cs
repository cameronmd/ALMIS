using ALMIS.Model;
using ALMIS.Repositories;
using System;
using System.Threading;

namespace ALMIS.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        private double _principalAmount;
        private double _productAReturn;
        private double _productBReturn;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public double PrincipalAmount
        {
            get { return _principalAmount; }
            set
            {
                _principalAmount = value;
                OnPropertyChanged(nameof(PrincipalAmount));
                CalculateReturns();
            }
        }

        public double ProductAReturn
        {
            get { return _productAReturn; }
            set
            {
                _productAReturn = value;
                OnPropertyChanged(nameof(ProductAReturn));
            }
        }

        public double ProductBReturn
        {
            get { return _productBReturn; }
            set
            {
                _productBReturn = value;
                OnPropertyChanged(nameof(ProductBReturn));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome, {user.Name} {user.LastName}!";
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
            }
        }

        public void CalculateReturns()
        {
            InvestmentProductModel productA = new InvestmentProductModel
            {
                Name = "Product A",
                InterestRate = 0.03,
                Compounding = CompoundingFrequency.Annually,
                MonthsFixed = 24
            };

            InvestmentProductModel productB = new InvestmentProductModel
            {
                Name = "Product B",
                InterestRate = 0.0295,
                Compounding = CompoundingFrequency.Monthly,
                MonthsFixed = 24
            };

            // Compund Interest Formula
            // A = P(1 + r / n) ^ (nt)
            //Where:
            //A = Final amount
            //P = Principal amount(initial investment)
            //r = Annual interest rate(in decimal form)
            //n = Number of times the interest is compounded per year
            //t = Number of years

            ProductAReturn = PrincipalAmount * (1 + productA.InterestRate);
            ProductBReturn = PrincipalAmount * Math.Pow((1 + productB.InterestRate / 12), (12 * (productB.MonthsFixed / 12)));
        }
    }
}
