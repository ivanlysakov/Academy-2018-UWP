using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportClient.ViewModels
{
    public class FlightViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private ObservableCollection<Flight> entities;
        private Flight entity;
        private Flight selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public FlightService Service { get; private set; }

        public FlightViewModel()
        {
            Service = new FlightService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new Flight();

        }

        public ObservableCollection<Flight> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public Flight Entity
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Entity != null)
                {
                    EntityId = entity.Id;
                }
                OnPropertyChanged("Entity");
            }
        }

        public Flight SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                selectedEntity = value;
                Entity = selectedEntity;
                OnPropertyChanged("Entity");
            }
        }

        public int EntityId
        {
            get { return entityID; }
            set
            {
                entityID = value;
                OnPropertyChanged("EntityId");
            }
        }

        void UpdateForm(object o)
        {
            Entity = new Flight();
        }

        async void Load()
        {
            Collection = new ObservableCollection<Flight>(await Service.Load());
        }

        async void Delete(object o)
        {
            await Service.Delete(Entity.Id);
            Entity = new Flight();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new Flight();
            Load();
        }

        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new Flight();
            Load();

        }
    }
}
