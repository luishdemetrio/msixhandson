using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerList.WPF.ViewModels
{
    public class CustomerListPageViewModel : BindableBase
    {

        public bool CheckForUpdates { get; set; }

        /// Creates a new CustomerListPageViewModel.
        public CustomerListPageViewModel()
        {  

            LoadConfig();
        
            GetCustomerListAsync().Wait();

        }


        private void LoadConfig()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Settings\\config.json";

            if (File.Exists(path))
            {
                string value = File.ReadAllText(path);
                var config = JsonConvert.DeserializeObject<Config>(value);

                CheckForUpdates = config.IsCheckForUpdatesEnabled;
            }
            else {
                CheckForUpdates = true;
            }
        }

        /// The collection of customers in the list. 
        public ObservableCollection<CustomerViewModel> Customers { get; }
            = new ObservableCollection<CustomerViewModel>();

        /// Gets the complete list of customers from the database.
        public async Task GetCustomerListAsync()
        {
          

            var customers = await App.Repository.Customers.GetAsync();

            if (customers == null)
            {
                return;
            }

           
            Customers.Clear();
            
            foreach (var c in customers)
            {
                Customers.Add(new CustomerViewModel(c));
            }
               
            
        }



        /// Queries the database for a current list of customers.
        public void Sync()
        {

            Task.Run(async () =>
            {
              
                foreach (var modifiedCustomer in Customers
                    .Where(customer => customer.IsModified).Select(customer => customer.Model))
                {
                    await App.Repository.Customers.UpsertAsync(modifiedCustomer);
                }

                await GetCustomerListAsync();
               
            });


        }
    }
}
