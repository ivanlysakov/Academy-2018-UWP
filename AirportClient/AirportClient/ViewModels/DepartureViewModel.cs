using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace AirportClient.ViewModels
{
    public class DepartureViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Departure> entities;
        private Departure entity;
        private Departure selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public DepartureService Service { get; private set; }

        public DepartureViewModel()
        {
            Service = new DepartureService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new Departure();

        }

        public ObservableCollection<Departure> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public Departure Entity
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

        public Departure SelectedEntity
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
            Entity = new Departure();
        }

        void Load()
        {
            Collection = new ObservableCollection<Departure>(Service.Load());
        }

        async void Delete(object o)
        {
            await Service.delete(Entity.Id);
            Entity = new Departure();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new Departure();
            Load();
        }

        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new Departure();
            Load();

        }
    }
}
