using System;
using System.Windows;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.ViewConstants;

namespace FlightManagement.Crew.AddCrewMember
{
    public class CloseAddCrewMemberCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not AddCrewMember addPlaneWindow || addPlaneWindow.DataContext is not CrewMemberViewModel crewMemberViewModel) throw new ArgumentNullException(nameof(parameter));
            
            if (!Validate(crewMemberViewModel, addPlaneWindow))
                return;

            addPlaneWindow.DialogResult = true;
            addPlaneWindow.Close();
        }

        public event EventHandler? CanExecuteChanged {add{} remove{}}

        private bool Validate(CrewMemberViewModel crewMemberViewModel, Window window)
        {
            if (string.IsNullOrEmpty(crewMemberViewModel.FirstName) || crewMemberViewModel.FirstName == StringStatic.FirstNamePlaceholder)
            {
                MessageBox.Show(window, "Podaj imię pracownika", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(crewMemberViewModel.LastName) || crewMemberViewModel.LastName == StringStatic.LastNamePlaceholder)
            {
                MessageBox.Show(window, "Podaj nazwisko pracownika", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(crewMemberViewModel.Position))
            {
                MessageBox.Show(window, "Podaj stanowisko pracownika", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(crewMemberViewModel.Street) || crewMemberViewModel.Street == StringStatic.StreetPlaceholder)
            {
                MessageBox.Show(window, "Podaj ulicę", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(crewMemberViewModel.HouseNumber) || crewMemberViewModel.HouseNumber == StringStatic.HomeNumberPlaceholder)
            {
                MessageBox.Show(window, "Podaj numer domu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(crewMemberViewModel.PostalCode) || crewMemberViewModel.PostalCode == StringStatic.PostalCodePlaceholder)
            {
                MessageBox.Show(window, "Podaj nazwisko pracownika", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(crewMemberViewModel.City) || crewMemberViewModel.City == StringStatic.CityPlaceholder)
            {
                MessageBox.Show(window, "Podaj miasto", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (crewMemberViewModel.PhoneNumber == 0)
            {
                MessageBox.Show(window, "Podaj numer telefonu pracownika", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(crewMemberViewModel.Email) || crewMemberViewModel.Email == StringStatic.EmailAddressPlaceholder)
            {
                MessageBox.Show(window, "Podaj adres e-mail pracownika", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
