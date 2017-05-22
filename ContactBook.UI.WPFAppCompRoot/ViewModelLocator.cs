/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ContactBook.UI.WPFAppCompRoot"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ContactBook.UI.WPFApp.ViewModel;
using ContactBook.DAL.Repositories;
using ContactBook.Domain;
using System.Configuration;

namespace ContactBook.UI.WPFAppCompRoot
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            string connString = ConfigurationManager.ConnectionStrings["ContactsDev"].ConnectionString;
            SimpleIoc.Default.Register<ContactsContext>(() => new ContactsContext(connString));
            SimpleIoc.Default.Register<IAddressRepository, AddressRepository>();
            SimpleIoc.Default.Register<IEmailRepository, EmailRepository>();
            SimpleIoc.Default.Register<IGroupRepository, GroupRepository>();
            SimpleIoc.Default.Register<IPhoneRepository, PhoneRepository>();
            SimpleIoc.Default.Register<IContactRepository, ContactRepository>();
            SimpleIoc.Default.Register<IUnitOfWork, UnitOfWork>();
            SimpleIoc.Default.Register<IContactService, ContactService>();

            SimpleIoc.Default.Register<ContactBookViewModel>();
        }

        public ContactBookViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ContactBookViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}